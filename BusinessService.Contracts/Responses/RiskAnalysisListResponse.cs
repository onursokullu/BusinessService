namespace BusinessService.Contracts.Responses
{
    public class RiskAnalysisListResponse
    {
        public Guid Id { get; set; }
        public Guid? BusinessTopicId { get; set; }
        public string Name { get; set; }
        public decimal? RiskScore { get; set; }

        public string? RiskDetails { get; set; }

        public string? RiskCategory { get; set; }

        public string? MitigationPlan { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
