using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;
using ECommerceDomain.Validators;

namespace ECommerceDomain.ValueObjects;

public sealed record Name : ValueObject<string?>
{
    public Name(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? name)
    {
        if (RegexExtensions.NameIsMatch(name) is false)
        {
            throw new NameFormatException().Target(nameof(Name));
        }
    }
}
