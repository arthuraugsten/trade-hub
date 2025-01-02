namespace TradeHub.Core.Domain;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public override bool Equals(object? obj) => Equals(obj as Entity);

    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(this, other))
            return true;

        if (other is null)
            return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode() => GetType().GetHashCode() + Id.GetHashCode();

    public static bool operator ==(Entity? a, Entity? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity? a, Entity? b)
        => !(a == b);
}