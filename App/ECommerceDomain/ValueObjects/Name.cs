using System.Text.RegularExpressions;
using ECommerceDomain.Abstractions;
using ECommerceDomain.Constants;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed record Name : ValueObject<string?>
{
    public Name(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? name)
    {
        if (Regex.IsMatch(name ?? "", RegexTypes.Name) is false)
        {
            throw new NameFormatException().SetTarget(nameof(Name));
        }
    }
}
