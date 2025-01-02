using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TradeHub.Products.Application.Commands.CreateProduct;

namespace TradeHub.Products.Presentation.Endpoints.CreateProduct;

public static class CreateProductEndpoint
{
    public static void MapProductEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/product", async (IMediator mediator, CreateProductRequest request, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new CreateProductCommand(request.Name), cancellationToken);

            if (result.IsSuccess)
            {
                return Results.CreatedAtRoute("/product/{id}", new { id = result.Value!.Id });
            }

            return Results.BadRequest(result.Errors);
        });
    }
}
