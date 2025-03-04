using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Api.Middlewares;
using BusinessService.Contracts.Responses;
using BusinessService.Data;
using BusinessService.Data.Abstractions;
using BusinessService.Data.Repositories;
using BusinessService.Logic.Abstractions;
using BusinessService.Logic.Profiles;
using BusinessService.Logic.Services;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BusinessServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency injections
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<BusinessServiceDbContext>>();

builder.Services.AddScoped<IBusinessTopicService, BusinessTopicService>();
builder.Services.AddScoped<IRiskAnalysisService, RiskAnalysisService>();
builder.Services.AddScoped<IRiskRuleService, RiskRuleService>();

builder.Services.AddScoped<IBusinessTopicRepository, BusinessTopicRepository>();
builder.Services.AddScoped<IRiskAnalysisRepository, RiskAnalysisRepository>();
builder.Services.AddScoped<IRiskRuleRepository, RiskRuleRepository>();

//Odata configuration
ODataConventionModelBuilder modelBuilder = new();

modelBuilder.EntitySet<GetBusinessTopicResponse>("business-topics");
builder.Services.AddControllers().AddOData(x =>
{
    x.Select().Filter().OrderBy().SetMaxTop(null).Count().Expand();
    x.AddRouteComponents("/api/v1", modelBuilder.GetEdmModel());
});

//Mappings
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new BusinessTopicProfile());
    cfg.AddProfile(new RiskAnalysisProfile());
    cfg.AddProfile(new RiskRuleProfile());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
