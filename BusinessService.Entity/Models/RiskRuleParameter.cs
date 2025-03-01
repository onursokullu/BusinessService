namespace BusinessService.Models;

public partial class RiskRuleParameter
{
    public Guid Id { get; set; }

    public Guid? RuleId { get; set; }

    public string? Name { get; set; }

    public string? ValueType { get; set; }

    public decimal? Weight { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual RiskRule? Rule { get; set; }
}
