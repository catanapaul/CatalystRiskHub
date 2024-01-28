using CatalystRiskHub.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalystRiskHub.DataAccess.Data
{
    public class CatalystRiskHubDbContext(DbContextOptions<CatalystRiskHubDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();
    }
}
