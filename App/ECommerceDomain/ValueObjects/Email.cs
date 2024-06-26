using ECommerceCommon.Exceptions;
using ECommerceCommon.Validations;
using ECommerceDomain.Abstraction;

namespace ECommerceDomain.ValueObjects;

public sealed record Email : ValueObject<string?>
{
    public Email(string? data, bool required = true) : base(data, required) { }

    protected override void Validate(string? email)
    {
        if (CustomRegexExtension.EmailIsMatch(email) is false)
        {
            throw new EmailFormatException().Target(nameof(Email));
        }
    }
}
