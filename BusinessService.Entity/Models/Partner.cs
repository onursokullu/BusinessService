namespace BusinessService.Models;

public partial class Partner
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public string? Industry { get; set; }

    public string? TaxNumber { get; set; }

    public int? CompanySize { get; set; }

    public string? Country { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();

    public virtual ICollection<BusinessTopic> BusinessTopics { get; set; } = new List<BusinessTopic>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
