using MediatR;
using TradeHub.Core.Application;

namespace TradeHub.Products.Application.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name) : IRequest<Result<CreateProductCommandResult>>;
