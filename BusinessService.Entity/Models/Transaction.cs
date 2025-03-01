namespace BusinessService.Models;

public partial class Transaction
{
    public Guid Id { get; set; }

    public Guid? PartnerId { get; set; }

    public Guid? AgreementId { get; set; }

    public decimal? Amount { get; set; }

    public string? Currency { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual Agreement? Agreement { get; set; }

    public virtual Partner? Partner { get; set; }
}
