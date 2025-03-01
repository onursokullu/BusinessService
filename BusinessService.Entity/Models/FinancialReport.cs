namespace BusinessService.Models;

public partial class FinancialReport
{
    public Guid Id { get; set; }

    public DateOnly? ReportDate { get; set; }

    public decimal? TotalRevenue { get; set; }

    public decimal? TotalRisk { get; set; }

    public decimal? ForecastAccuracy { get; set; }

    public decimal? Expenses { get; set; }

    public decimal? NetProfit { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Forecast> Forecasts { get; set; } = new List<Forecast>();
}
