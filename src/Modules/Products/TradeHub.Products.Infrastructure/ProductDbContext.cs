using Microsoft.EntityFrameworkCore;
using TradeHub.Products.Domain;

namespace TradeHub.Products.Infrastructure;

public sealed class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public const string MigrationHistoryTableName = "__EFMigrationsHistory";
    public const string SchemaName = "Products";

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);
        modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureAssemblyInfo.Assembly);
    }
}
