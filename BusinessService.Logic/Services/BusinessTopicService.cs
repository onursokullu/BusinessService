using AutoMapper;
using BusinessService.Contracts.Responses;
using BusinessService.Data.Abstractions;
using BusinessService.Logic.Abstractions;
using BusinessService.Logic.Errors.Common;
using Microsoft.Extensions.Logging;

namespace BusinessService.Logic.Services
{
    public class BusinessTopicService : IBusinessTopicService
    {
        private readonly ILogger<BusinessTopicService> _logger;
        private readonly IBusinessTopicRepository _businessTopicRepository;
        private readonly IMapper _mapper;

        public BusinessTopicService(ILogger<BusinessTopicService> logger, IBusinessTopicRepository businessTopicRepository,
            IMapper mapper)
        {
            _logger = logger;
            _businessTopicRepository = businessTopicRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetBusinessTopicResponse>> GetBusinessTopicByFilter()
        {
            _logger.LogDebug("Start: GetBusinessTopicByFilter");

            try
            {
                var businessTopics = _mapper.ProjectTo<GetBusinessTopicResponse>(_businessTopicRepository.GetAll());
                _logger.LogInformation("End: GetBusinessTopicByFilter. Successfully retrieved business topics.");

                return businessTopics;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "End: GetBusinessTopicByFilter. An error occurred while fetching business topics.");
                throw new AppException(new AppError(System.Net.HttpStatusCode.InternalServerError, "somethingWentWrong", "Something went wrong"));
            }
        }
    }
}
