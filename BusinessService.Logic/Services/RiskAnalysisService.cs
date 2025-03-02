using System.Data;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using BusinessService.Contracts.Requests;
using BusinessService.Contracts.Responses;
using BusinessService.Data.Abstractions;
using BusinessService.Logic.Errors.Common;
using BusinessService.Models;
using Microsoft.Extensions.Logging;

namespace BusinessService.Logic.Services
{
    public class RiskAnalysisService : IRiskAnalysisService
    {
        private readonly ILogger<RiskAnalysisService> _logger;
        private readonly IRiskAnalysisRepository _riskAnalysisRepository;
        private readonly IMapper _mapper;
        private readonly IRiskRuleRepository _riskRuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RiskAnalysisService(ILogger<RiskAnalysisService> logger, IRiskAnalysisRepository riskAnalysisRepository,
                            IMapper mapper, IRiskRuleRepository riskRuleRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _riskAnalysisRepository = riskAnalysisRepository;
            _mapper = mapper;
            _riskRuleRepository = riskRuleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RiskAnalysisListResponse>> GetRiskAnalysisList(Guid businessTopicId)
        {
            _logger.LogDebug("Start: GetRiskAnalysisList");

            var riskAnalysisDetail = await _riskAnalysisRepository.
                                      GetRiskAnalysisListByBusinessTopicId(businessTopicId);

            if (!riskAnalysisDetail.Any())
            {
                _logger.LogInformation("End: GetRiskAnalysisList. Fail. Risk analysis detail not found.");

                throw new AppException(new AppError(HttpStatusCode.NotFound, "riskRuleNotFound", "Risk rule not found"));
            }

            _logger.LogInformation("End: GetRiskAnalysisList.");

            try
            {
                return _mapper.Map<List<RiskAnalysisListResponse>>(riskAnalysisDetail);
            }
            catch (Exception)
            {
                throw new AppException(new AppError(HttpStatusCode.InternalServerError, "mappingError", "An error occured while mapping."));

            }
        }


        public async Task<RiskAnalysisListResponse> GetRiskAnalysisDetail(Guid riskAnalysisId)
        {
            _logger.LogDebug("Start: GetRiskAnalysisDetail");

            var riskAnalysisDetail = await _riskAnalysisRepository
                                        .GetFirstOrDefaultAsync(predicate: x => x.Id == riskAnalysisId && x.IsActive == true);

            if (riskAnalysisDetail == null)
            {
                _logger.LogInformation("End: GetRiskAnalysisDetail. Fail. Risk analysis detail not found.");

                throw new AppException(new AppError(HttpStatusCode.NotFound, "riskRuleNotFound", "Risk rule not found"));
            }

            _logger.LogInformation("End: GetBusinessTopicByFilter.");

            try
            {
                return _mapper.Map<RiskAnalysisListResponse>(riskAnalysisDetail);
            }
            catch (Exception)
            {
                throw new AppException(new AppError(HttpStatusCode.InternalServerError, "mappingError", "An error occured while mapping."));
            }
        }

        public async Task<CreateRiskAnalysisResponse> CreateRiskAnalysis(CreateRiskAnalysisRequest request)
        {
            _logger.LogDebug("Start: CreateRiskAnalysis");

            var riskScore = await CalculateRiskScore(request.RiskRuleName, request.RiskParameters);

            var riskAnalysis = _mapper.Map<RiskAnalysis>(request);
            riskAnalysis.RiskScore = riskScore;

            await _riskAnalysisRepository.InsertAsync(riskAnalysis);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result == 0)
            {
                _logger.LogError("End: GetBusinessTopicByFilter. An error occured while adding risk analysis.");

                throw new AppException(new AppError(HttpStatusCode.InternalServerError, "riskAnalysisCouldntAddedError", "An error occured while adding risk analysis."));

            }

            _logger.LogDebug("End: CreateRiskAnalysis. Success");

            return new CreateRiskAnalysisResponse { RiskAnalysisId = riskAnalysis.Id };
        }

        private async Task<decimal> CalculateRiskScore(string riskRuleName, Dictionary<string, decimal> parameterValues)
        {
            var riskRule = await _riskRuleRepository.GetRiskRuleWithParameters(riskRuleName);

            if (riskRule == null)
            {
                throw new AppException(new AppError(HttpStatusCode.NotFound, "riskRuleNotFound", "Risk rule not found"));

            }

            string formula = riskRule.Expression;

            foreach (var param in parameterValues)
            {
                formula = Regex.Replace(formula, $@"\b{Regex.Escape(param.Key)}\b", param.Value.ToString(CultureInfo.InvariantCulture));
            }

            var result = EvaluateExpression(formula);
            return result;
        }

        private static decimal EvaluateExpression(string expression)
        {
            return Convert.ToDecimal(new DataTable().Compute(expression, null));
        }
    }
}
