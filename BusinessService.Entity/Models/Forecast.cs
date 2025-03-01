namespace BusinessService.Models;

public partial class Forecast
{
    public Guid Id { get; set; }

    public Guid? ReportId { get; set; }

    public decimal? ForecastedValue { get; set; }

    public decimal? ActualValue { get; set; }

    public decimal? Accuracy { get; set; }

    public string? PredictionModel { get; set; }

    public decimal? ConfidenceInterval { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual FinancialReport? Report { get; set; }
}
