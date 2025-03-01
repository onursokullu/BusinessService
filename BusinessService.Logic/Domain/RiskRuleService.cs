using System.Net;
using AutoMapper;
using BusinessService.Contracts.Responses;
using BusinessService.Data.Abstractions;
using BusinessService.Logic.Abstractions;
using BusinessService.Logic.Errors.Common;
using Microsoft.EntityFrameworkCore;

namespace BusinessService.Logic.Domain
{
    public class RiskRuleService : IRiskRuleService
    {
        private IRiskRuleRepository _iRiskRuleRepository;
        private readonly IMapper _mapper;

        public RiskRuleService(IRiskRuleRepository iRiskRuleRepository, IMapper mapper)
        {
            _iRiskRuleRepository = iRiskRuleRepository;
            _mapper = mapper;
        }

        public async Task<RiskRuleResponse> GetRiskRuleByName(string name)
        {
            var riskRule = await _iRiskRuleRepository.GetFirstOrDefaultAsync(predicate: x => x.Name == name,
                                    include: rule => rule.Include(y => y.RiskRuleParameters));

            if (riskRule == null)
            {
                throw new AppException(new AppError(HttpStatusCode.NotFound, "riskRuleNotFound", "Risk rule not found"));
            }

            return _mapper.Map<RiskRuleResponse>(riskRule);
        }
    }
}
