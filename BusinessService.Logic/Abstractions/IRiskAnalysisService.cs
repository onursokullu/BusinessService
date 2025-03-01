using BusinessService.Contracts.Requests;
using BusinessService.Contracts.Responses;

namespace BusinessService.Data.Abstractions
{
    public interface IRiskAnalysisService
    {
        public Task<List<RiskAnalysisListResponse>> GetRiskAnalysisList(Guid businessTopicId);
        public Task<RiskAnalysisListResponse> GetRiskAnalysisDetail(Guid riskAnalysisId);
        public Task<CreateRiskAnalysisResponse> CreateRiskAnalysis(CreateRiskAnalysisRequest request);
    }
}
