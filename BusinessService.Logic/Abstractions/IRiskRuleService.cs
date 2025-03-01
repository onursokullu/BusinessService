using BusinessService.Contracts.Responses;

namespace BusinessService.Logic.Abstractions
{
    public interface IRiskRuleService
    {
        public Task<RiskRuleResponse> GetRiskRuleByName(string name);
    }
}
