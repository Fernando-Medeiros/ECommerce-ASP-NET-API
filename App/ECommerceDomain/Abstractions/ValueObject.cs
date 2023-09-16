namespace ECommerceDomain.Abstractions;

public abstract class ValueObject<T>
{
    public T? Value { get; init; }

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

    public static implicit operator T?(ValueObject<T?> valueObject)
    {
        return valueObject.Value;
    }

    #endregion
}