using TradeHub.Products.Domain;

namespace TradeHub.Products.Application.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
