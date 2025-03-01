using BusinessService.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessService.Data;

public partial class BusinessServiceDbContext : DbContext
{
    public BusinessServiceDbContext()
    {
    }

    public BusinessServiceDbContext(DbContextOptions<BusinessServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agreement> Agreements { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<BusinessTopic> BusinessTopics { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<FinancialReport> FinancialReports { get; set; }

    public virtual DbSet<Forecast> Forecasts { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<RiskAnalysis> RiskAnalyses { get; set; }

    public virtual DbSet<RiskRule> RiskRules { get; set; }

    public virtual DbSet<RiskRuleParameter> RiskRuleParameters { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BusinessService;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agreement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agreemen__3213E83F197C5E64");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BusinessTopicId).HasColumnName("business_topic_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PaymentTerms)
                .HasColumnType("text")
                .HasColumnName("payment_terms");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.BusinessTopic).WithMany(p => p.Agreements)
                .HasForeignKey(d => d.BusinessTopicId)
                .HasConstraintName("FK__Agreement__busin__5535A963");

            entity.HasOne(d => d.Partner).WithMany(p => p.Agreements)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Agreement__partn__5070F446");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Audit_Lo__3213E83F6B333C12");

            entity.ToTable("Audit_Log");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Audit_Log__user___787EE5A0");
        });

        modelBuilder.Entity<BusinessTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Business__3213E83F45CAEA95");

            entity.ToTable("Business_Topics");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.TopicName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("topic_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Partner).WithMany(p => p.BusinessTopics)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Business___partn__440B1D61");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3213E83FEB4CE858");

            entity.HasIndex(e => e.Email, "UQ__Contacts__AB6E6164996D9509").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Company).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Contacts__compan__4AB81AF0");
        });

        modelBuilder.Entity<FinancialReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Financia__3213E83F0509D904");

            entity.ToTable("Financial_Reports");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Expenses)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("expenses");
            entity.Property(e => e.ForecastAccuracy)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("forecast_accuracy");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.NetProfit)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("net_profit");
            entity.Property(e => e.ReportDate).HasColumnName("report_date");
            entity.Property(e => e.TotalRevenue)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("total_revenue");
            entity.Property(e => e.TotalRisk)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("total_risk");
        });

        modelBuilder.Entity<Forecast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forecast__3213E83F44B957DE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Accuracy)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("accuracy");
            entity.Property(e => e.ActualValue)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("actual_value");
            entity.Property(e => e.ConfidenceInterval)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("confidence_interval");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ForecastedValue)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("forecasted_value");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PredictionModel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("prediction_model");
            entity.Property(e => e.ReportId).HasColumnName("report_id");

            entity.HasOne(d => d.Report).WithMany(p => p.Forecasts)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("FK__Forecasts__repor__60A75C0F");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partners__3213E83F6754E198");

            entity.HasIndex(e => e.TaxNumber, "UQ__Partners__8A87F631D9F93EFC").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompanySize).HasColumnName("company_size");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contact_info");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Industry)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("industry");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RiskAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Risk_Ana__3213E83F79DCD91C");

            entity.ToTable("Risk_Analysis");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BusinessTopicId).HasColumnName("business_topic_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MitigationPlan)
                .HasColumnType("text")
                .HasColumnName("mitigation_plan");
            entity.Property(e => e.RiskCategory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("risk_category");
            entity.Property(e => e.RiskDetails)
                .HasColumnType("text")
                .HasColumnName("risk_details");
            entity.Property(e => e.RiskScore)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("risk_score");

            entity.HasOne(d => d.BusinessTopic).WithMany(p => p.RiskAnalyses)
                .HasForeignKey(d => d.BusinessTopicId)
                .HasConstraintName("FK__Risk_Anal__busin__5812160E");
        });

        modelBuilder.Entity<RiskRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Risk_Rul__3213E83F8F70EB0A");

            entity.ToTable("Risk_Rules");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Expression)
                .HasColumnType("text")
                .HasColumnName("expression");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RiskRuleParameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Risk_Rul__3213E83FDC90F30E");

            entity.ToTable("Risk_Rule_Parameters");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RuleId).HasColumnName("rule_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.ValueType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("value_type");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.Rule).WithMany(p => p.RiskRuleParameters)
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("FK__Risk_Rule__rule___6A30C649");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3213E83F8558CCEE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AgreementId).HasColumnName("agreement_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");

            entity.HasOne(d => d.Agreement).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AgreementId)
                .HasConstraintName("FK__Transacti__agree__71D1E811");

            entity.HasOne(d => d.Partner).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK__Transacti__partn__70DDC3D8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FA8190503");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E616422975FF0").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572B257C47A").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("text")
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
