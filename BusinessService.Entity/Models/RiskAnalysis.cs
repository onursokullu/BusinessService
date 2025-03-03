namespace BusinessService.Models;

public partial class RiskAnalysis
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }
    public Guid? BusinessTopicId { get; set; }

    public decimal? RiskScore { get; set; }

    public string? RiskDetails { get; set; }

    public string? RiskCategory { get; set; }

    public string? MitigationPlan { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public bool? IsActive { get; set; } = true;

    public virtual BusinessTopic? BusinessTopic { get; set; }
}
