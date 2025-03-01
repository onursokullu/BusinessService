namespace BusinessService.Models;

public partial class AuditLog
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Action { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? Details { get; set; }

    public virtual User? User { get; set; }
}
