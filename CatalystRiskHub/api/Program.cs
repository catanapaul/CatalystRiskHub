using CatalystRiskHub.DataAccess.Data;
using CatalystRiskHub.Endpoints;
using CatalystRiskHub.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddApiCors(builder.Configuration);
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddDbContext<CatalystRiskHubDbContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.MapProductsEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseApiCors();
app.UseHttpsRedirection();

app.Run();
