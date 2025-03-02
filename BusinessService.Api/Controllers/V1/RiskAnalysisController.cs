using System.ComponentModel.DataAnnotations;
using BusinessService.Contracts.Requests;
using BusinessService.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskAnalysisController : ControllerBase
    {
        private readonly ILogger<RiskAnalysisController> _logger;
        private readonly IRiskAnalysisService _riskAnalysisService;

        public RiskAnalysisController(IRiskAnalysisService riskAnalysisService)
        {
            _riskAnalysisService = riskAnalysisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRiskAnalysisList([Required][FromRoute] Guid businessTopicId)
        {
            _logger.LogDebug("Start:GetRiskAnalysisList");

            var riskAnalysisList = await _riskAnalysisService.GetRiskAnalysisList(businessTopicId);

            _logger.LogDebug("Success:GetRiskAnalysisList");

            return Ok(riskAnalysisList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRiskAnalysis([Required][FromBody] CreateRiskAnalysisRequest createRiskAnalysisRequest)
        {
            _logger.LogDebug("Start:CreateRiskAnalysis");

            var riskAnalysisList = await _riskAnalysisService.CreateRiskAnalysis(createRiskAnalysisRequest);

            _logger.LogDebug("Success:CreateRiskAnalysis");

            return Ok(riskAnalysisList);

        }
    }
}