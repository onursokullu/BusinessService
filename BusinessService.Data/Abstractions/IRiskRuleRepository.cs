using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Models;

namespace BusinessService.Data.Abstractions
{
    public interface IRiskRuleRepository : IRepository<RiskRule>
    {
        public Task<RiskRule> GetRiskRuleWithParameters(string riskRuleName);

    }
}
