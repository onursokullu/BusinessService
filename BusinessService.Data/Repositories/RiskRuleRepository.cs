using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Data.Abstractions;
using BusinessService.Models;

namespace BusinessService.Data.Repositories
{
    public class RiskRuleRepository(BusinessServiceDbContext context) : Repository<RiskRule>(context), IRiskRuleRepository
    {

    }
}