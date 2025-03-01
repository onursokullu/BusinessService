namespace BusinessService.Models;

public partial class RiskAnalysis
{
    public Guid Id { get; set; }

    public Guid? BusinessTopicId { get; set; }

    public decimal? RiskScore { get; set; }

    public string? RiskDetails { get; set; }

    public string? RiskCategory { get; set; }

    public string? MitigationPlan { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual BusinessTopic? BusinessTopic { get; set; }
}
