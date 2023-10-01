namespace ECommerceDomain.Abstractions;

public abstract record ValueObject<T>
{
    public T? Value { get; private init; }

    public ValueObject(T? data, bool required = true)
    {
        if (required || data is T) Validate(data);

        Value = data;
    }

    public abstract void Validate(T? data);

    public static implicit operator T?(ValueObject<T?> obj) { return obj.Value; }
}