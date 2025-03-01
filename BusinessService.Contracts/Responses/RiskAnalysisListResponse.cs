namespace BusinessService.Contracts.Responses
{
    public class RiskAnalysisListResponse
    {
        public Guid? BusinessTopicId { get; set; }

        public decimal? RiskScore { get; set; }

        public string? RiskDetails { get; set; }

        public string? RiskCategory { get; set; }

        public string? MitigationPlan { get; set; }
    }
}
