using System.Collections.ObjectModel;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.Validators;

public static class ValidatorExtensions
{
    static readonly string Target = nameof(ValidatorExtensions);

    public static CustomValidator<T> NotNull<T>(this CustomValidator<T> v)
    {
        if (v.Value == null)
            throw new NotNullException(v.Target).Target(Target);
        return v;
    }

    public static CustomValidator<T> NotEmpty<T>(this CustomValidator<T> v)
    {
        bool IsEmpty = false;

        if (v.Value is string str) IsEmpty = string.IsNullOrWhiteSpace(str);

        if (v.Value is Collection<T> collection) IsEmpty = collection.Count == 0;

        if (v.IsRequired() && IsEmpty)

            throw new NotEmptyException(v.Target).Target(Target);
        return v;
    }

    public static CustomValidator<T> Length<T>(this CustomValidator<T> v, int min, int max)
    {
        int len = $"{v.Value}".Length;

        if (v.IsRequired() && len < min || len > max)

            throw new LengthException(v.Target, min, max).Target(Target);
        return v;
    }

    public static CustomValidator<T> EmailAddress<T>(this CustomValidator<T> v)
    {
        if (v.IsRequired() && !RegexExtensions.EmailIsMatch(v.Value))

            throw new EmailFormatException().Target(Target);
        return v;
    }


    public static CustomValidator<T> Password<T>(this CustomValidator<T> v)
    {
        if (v.IsRequired() && !RegexExtensions.PasswordIsMatch(v.Value))

            throw new PasswordFormatException().Target(Target);
        return v;
    }
}
