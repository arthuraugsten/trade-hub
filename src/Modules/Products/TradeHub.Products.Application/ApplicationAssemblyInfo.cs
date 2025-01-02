using System.Reflection;

namespace TradeHub.Products.Application;

public static class ApplicationAssemblyInfo
{
    public static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();
}
