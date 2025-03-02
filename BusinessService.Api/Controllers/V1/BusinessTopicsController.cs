using BusinessService.Logic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;

namespace BusinessService.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BusinessTopicsController : ControllerBase
    {
        private readonly IBusinessTopicService _businessTopicService;
        private readonly ILogger<BusinessTopicsController> _logger;

        public BusinessTopicsController(IBusinessTopicService businessTopicService, ILogger<BusinessTopicsController> logger)
        {
            _businessTopicService = businessTopicService;
            _logger = logger;
        }
        [HttpGet]
        [EnableQuery]
        [ODataRouteComponent("/api/v1/business-topics")]
        public async Task<IActionResult> GetBusinessTopicsByFilter()
        {
            _logger.LogDebug("Start:GetBusinessTopicsByFilter");

            var businessTopics = await _businessTopicService.GetBusinessTopicByFilter();

            _logger.LogDebug("Success:GetBusinessTopicsByFilter");

            return Ok(businessTopics);
        }
    }
}
