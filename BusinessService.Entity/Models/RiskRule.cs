namespace BusinessService.Models;

public partial class RiskRule
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Expression { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<RiskRuleParameter> RiskRuleParameters { get; set; } = new List<RiskRuleParameter>();
}
