namespace BusinessService.Contracts.Requests
{
    public class CreateRiskAnalysisRequest
    {
        public string Name { get; set; }
        public string RiskRuleName { get; set; }
        public Dictionary<string, decimal> RiskParameters { get; set; }
        public Guid BusinessTopicId { get; set; }
        public string RiskDetails { get; set; }
        public string RiskCategory { get; set; }
        public string? MitigationPlan { get; set; }
    }
}
