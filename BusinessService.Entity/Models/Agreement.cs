namespace BusinessService.Models;

public partial class Agreement
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Amount { get; set; }

    public string? Currency { get; set; }

    public string? PaymentTerms { get; set; }

    public Guid? PartnerId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public Guid? BusinessTopicId { get; set; }

    public virtual BusinessTopic? BusinessTopic { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
