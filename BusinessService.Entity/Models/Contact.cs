namespace BusinessService.Models;

public partial class Contact
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; }

    public string? Department { get; set; }

    public Guid? CompanyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual Partner? Company { get; set; }
}
