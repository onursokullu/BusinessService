using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Models;

namespace BusinessService.Data.Abstractions
{
    public interface IBusinessTopicRepository : IRepository<BusinessTopic>
    {
    }
}
