using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Data.Abstractions;
using BusinessService.Models;

namespace BusinessService.Data.Repositories
{
    public class BusinessTopicRepository(BusinessServiceDbContext context) : Repository<BusinessTopic>(context), IBusinessTopicRepository
    {
        
    }
}
