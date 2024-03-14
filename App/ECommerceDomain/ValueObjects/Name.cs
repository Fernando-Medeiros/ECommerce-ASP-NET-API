using ECommerceCommon.Exceptions;
using ECommerceCommon.Validations;
using ECommerceDomain.Abstraction;

namespace ECommerceDomain.ValueObjects;

public sealed record Name : ValueObject<string?>
{
    public Name(string? data, bool required = true) : base(data, required) { }

    protected override void Validate(string? name)
    {
        if (CustomRegexExtension.NameIsMatch(name) is false)
        {
            throw new NameFormatException().Target(nameof(Name));
        }
    }
}
