using FluentValidation;
using MediatR;

namespace TradeHub.Core.Application;

public class PipelineRequestValidator<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, Result<TResponse?>> where TRequest : IRequest<TResponse?>
{
    public async Task<Result<TResponse?>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse?>> next, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(next);

        var context = new ValidationContext<TRequest>(request);

        foreach (var validator in validators ?? [])
        {
            if (await validator.ValidateAsync(context, cancellationToken) is { IsValid: false } validationResult)
            {
                var errors = new List<Error>();

                foreach (var error in validationResult.Errors.Where(t => t is not null))
                {
                    errors.Add(new Error(error.ErrorCode, error.ErrorMessage));
                }

                return Result<TResponse?>.Failure(errors);
            }
        }

        return await next();
    }
}

