namespace TradeHub.Products.Domain;

public sealed class Product
{
    private Product(string name)
    {
        Name = name;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }

    public static Product Create(string name)
    {
        return new Product(name);
    }
}
