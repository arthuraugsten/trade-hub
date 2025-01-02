using MediatR;
using TradeHub.Core.Application;
using TradeHub.Products.Domain;
using TradeHub.Products.Application.Repositories;

namespace TradeHub.Products.Application.Commands.CreateProduct;

public sealed class CreateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, Result<CreateProductCommandResult>>
{
    public async Task<Result<CreateProductCommandResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name);
        await productRepository.AddAsync(product, cancellationToken);
        await productRepository.SaveAsync(cancellationToken);

        return Result<CreateProductCommandResult>.Success(new(product.Id));
    }
}
