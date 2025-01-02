using TradeHub.Products.Application.Repositories;
using TradeHub.Products.Domain;

namespace TradeHub.Products.Infrastructure.Repositories;

public sealed class ProductRepository(ProductDbContext dbContext) : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await dbContext.Products.AddAsync(product, cancellationToken);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
