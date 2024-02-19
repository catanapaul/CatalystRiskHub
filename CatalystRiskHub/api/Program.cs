using CatalystRiskHub.DataAccess.Data;
using CatalystRiskHub.Endpoints;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddDbContext<CatalystRiskHubDbContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
// builder.Services.Configure<SwaggerGeneratorOptions>(o => { o.InferSecuritySchemes = true; });
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.MapProductsEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.Run();
