using System.Collections.ObjectModel;
using ECommerceCommon.Exceptions;

namespace ECommerceCommon.Validations;

public static class CustomValidationExtension
{
    static readonly string Target = nameof(CustomValidationExtension);

    public static CustomValidation<T> NotNull<T>(this CustomValidation<T> v)
    {
        if (v.Value is null)
            throw new NotNullException(v.Target).Target(Target);
        return v;
    }

    public static CustomValidation<T> NotEmpty<T>(this CustomValidation<T> v)
    {
        bool IsEmpty = false;

        if (v.Value is string str) IsEmpty = string.IsNullOrWhiteSpace(str);

        if (v.Value is Collection<T> collection) IsEmpty = collection.Count == 0;

        if (v.IsRequired() && IsEmpty)

            throw new NotEmptyException(v.Target).Target(Target);
        return v;
    }

    public static CustomValidation<T> Length<T>(this CustomValidation<T> v, int min, int max)
    {
        int len = $"{v.Value}".Length;

        if (v.IsRequired() && len < min || len > max)

            throw new LengthException(v.Target, min, max).Target(Target);
        return v;
    }

    public static CustomValidation<T> EmailAddress<T>(this CustomValidation<T> v)
    {
        if (v.IsRequired() && CustomRegexExtension.EmailIsMatch(v.Value) is false)

            throw new EmailFormatException().Target(Target);
        return v;
    }


    public static CustomValidation<T> Password<T>(this CustomValidation<T> v)
    {
        if (v.IsRequired() && CustomRegexExtension.PasswordIsMatch(v.Value) is false)

            throw new PasswordFormatException().Target(Target);
        return v;
    }
}
