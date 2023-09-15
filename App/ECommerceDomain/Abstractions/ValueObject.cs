namespace ECommerceDomain.Abstractions;

public abstract class ValueObject<T>
{
    public T? Value { get; private set; }

    public bool Required { get; private set; } = true;

    public ValueObject<T> Set(T data) { Value = data; return this; }

    public ValueObject<T> Optional() { Required = false; return this; }


    #region Abstractions

    public abstract ValueObject<T> Validate(T data);

    #endregion

    #region Operators

    public static implicit operator T?(ValueObject<T?> valueObject)
    {
        return valueObject.Value;
    }

    #endregion
}
