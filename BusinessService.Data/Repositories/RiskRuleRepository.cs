using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Data.Abstractions;
using BusinessService.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessService.Data.Repositories
{
    public class RiskRuleRepository(BusinessServiceDbContext context) : Repository<RiskRule>(context), IRiskRuleRepository
    {
        public async Task<RiskRule> GetRiskRuleWithParameters(string riskRuleName)
        {
            return await context.RiskRules.Where(rule => rule.Name == riskRuleName && rule.IsActive == true)!
                 .Include(rule => rule.RiskRuleParameters.Where(param => param.IsActive == true))!
                 .FirstOrDefaultAsync(); 
        }

    }
}