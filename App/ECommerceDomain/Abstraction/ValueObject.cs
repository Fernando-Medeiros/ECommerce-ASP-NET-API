namespace ECommerceDomain.Abstraction;

public abstract record ValueObject<T>
{
    public T? Value { get; private init; }

    public ValueObject(T? value, bool required = true)
    {
        if (required || value is T) Validate(value);

        Value = value;
    }

    protected abstract void Validate(T? data);

    public static implicit operator T?(ValueObject<T?>? obj)
    {
        return obj is not null ? obj.Value : default;
    }
}