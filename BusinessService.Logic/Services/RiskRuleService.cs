using System.Net;
using AutoMapper;
using BusinessService.Contracts.Responses;
using BusinessService.Data.Abstractions;
using BusinessService.Logic.Abstractions;
using BusinessService.Logic.Errors.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BusinessService.Logic.Services
{
    public class RiskRuleService : IRiskRuleService
    {
        private readonly ILogger<RiskRuleService> _logger;
        private IRiskRuleRepository _riskRuleRepository;
        private readonly IMapper _mapper;

        public RiskRuleService(IRiskRuleRepository iRiskRuleRepository, IMapper mapper)
        {
            _riskRuleRepository = iRiskRuleRepository;
            _mapper = mapper;
        }

        public async Task<RiskRuleResponse> GetRiskRuleByName(string name)
        {

            _logger.LogDebug("Start: GetRiskRuleByName");

            var riskRule = await _riskRuleRepository.GetFirstOrDefaultAsync(predicate: x => x.Name == name,
                                    include: rule => rule.Include(y => y.RiskRuleParameters));

            if (riskRule == null)
            {
                _logger.LogInformation("End: GetRiskRuleByName. Fail. Risk rule not found.");

                throw new AppException(new AppError(HttpStatusCode.NotFound, "riskRuleNotFound", "Risk rule not found"));
            }

            _logger.LogInformation("End: GetRiskRuleByName. Success.");

            return _mapper.Map<RiskRuleResponse>(riskRule);
        }
    }
}
