using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.Abstractions;

public abstract class Entity
{
    public UUID Id { get; protected set; } = new();
    public DateTimeOffset? UpdatedAt { get; protected set; }
    public DateTimeOffset? CreatedAt { get; protected set; }
}
