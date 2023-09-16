using ECommerceDomain.ValueObjects;

namespace ECommerceDomain.Abstractions;

public abstract class Entity
{
    public UUID? Id { get; protected set; }
    public Date? UpdatedOn { get; protected set; }
    public Date? CreatedOn { get; protected set; }
}
