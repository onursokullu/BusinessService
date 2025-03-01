namespace BusinessService.Models;

public partial class BusinessTopic
{
    public Guid Id { get; set; }

    public Guid? PartnerId { get; set; }

    public string TopicName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();

    public virtual Partner? Partner { get; set; }

    public virtual ICollection<RiskAnalysis> RiskAnalyses { get; set; } = new List<RiskAnalysis>();
}
