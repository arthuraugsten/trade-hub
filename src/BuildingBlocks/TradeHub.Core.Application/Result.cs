namespace TradeHub.Core.Application;

public class Result<T>
{
    protected internal Result(T? value, List<Error>? errors = default)
    {
        IsSuccess = value is not { };

        if (IsSuccess && errors is not null)
        {
            throw new InvalidOperationException();
        }

        if (!IsSuccess && errors is null)
        {
            throw new InvalidOperationException();
        }

        Value = value;
        Errors = errors ?? [];
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public List<Error>? Errors { get; }
    public T? Value { get; }

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator T(Result<T> result) => result.Value!;

    public static Result<T> Success(T value) => value;
    public static Result<T> Failure(Error error) => new(default, [error]);
    public static Result<T> Failure(List<Error> errors) => new(default, errors);
}