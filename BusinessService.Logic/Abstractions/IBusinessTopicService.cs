using BusinessService.Contracts.Responses;

namespace BusinessService.Logic.Abstractions
{
    public interface IBusinessTopicService
    {
        public Task<IQueryable<GetBusinessTopicResponse>> GetBusinessTopicByFilter();
    }
}
