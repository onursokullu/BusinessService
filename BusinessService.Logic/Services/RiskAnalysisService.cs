using System.Net;
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

        public RiskAnalysisService(ILogger<RiskAnalysisService> logger, IRiskAnalysisRepository riskAnalysisRepository,
                            IMapper mapper)
        {
            _logger = logger;
            _riskAnalysisRepository = riskAnalysisRepository;
            _mapper = mapper;
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

        public Task<CreateRiskAnalysisResponse> CreateRiskAnalysis(CreateRiskAnalysisRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
