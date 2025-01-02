namespace TradeHub.Core.Application;

public record Error(string Code, string Message)
{
    public static Error None { get; } = new(string.Empty, string.Empty);
}
