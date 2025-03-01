using BusinessService.Contracts.Responses;
using BusinessService.Logic.Profiles;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// dependency injections

//odata configuration
ODataConventionModelBuilder modelBuilder = new();

modelBuilder.EntitySet<GetBusinessTopicResponse>("business-topics");
builder.Services.AddControllers().AddOData(x =>
{
    x.Select().Filter().OrderBy().SetMaxTop(null).Count().Expand();
    x.AddRouteComponents("/api/v1", modelBuilder.GetEdmModel());
});

//mappings
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new BusinessTopicProfile());
    cfg.AddProfile(new RiskAnalysisProfile());
    cfg.AddProfile(new RiskRuleProfile());
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
