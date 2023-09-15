using System.Text.RegularExpressions;
using ECommerceDomain.Abstractions;
using ECommerceDomain.Constants;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed class Name : ValueObject<string?>
{
    public override ValueObject<string?> Validate(string? name)
    {
        if (Required && Regex.IsMatch(name ?? "", RegexTypes.Name) is false)
        {
            throw new NameFormatException().SetTarget(nameof(Name));
        }
        return this;
    }
}
