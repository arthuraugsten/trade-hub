using System.Reflection;

namespace TradeHub.Products.Infrastructure;

public static class InfrastructureAssemblyInfo
{
    public static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();
}
