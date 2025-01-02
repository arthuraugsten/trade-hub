using FluentValidation;
using TradeHub.Products.Application.Commands.CreateProduct;

namespace TradeHub.Products.Application.Commands.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty()
            .WithErrorCode("PRODUCT-001")
            .MinimumLength(3)
            .WithErrorCode("PRODUCT-002")
            .MaximumLength(256)
            .WithErrorCode("PRODUCT-003");
    }
}
