namespace ECommerceDomain.Abstractions;

public abstract record ValueObject<T>
{
    public T? Value { get; private init; }

    public ValueObject(T? data, bool required = true)
    {
        if (required || data != null)
            Validate(data);

        Value = data;
    }

    #region Abstractions

    public abstract void Validate(T? data);

    #endregion

    #region Operators

    public static implicit operator T?(ValueObject<T?> obj)
    {
        return obj.Value;
    }

    #endregion
}