using System.Text.RegularExpressions;
using ECommerceDomain.Constants;

namespace ECommerceDomain.Validators;

public static partial class RegexExtensions
{
    [GeneratedRegex(RegexTypes.Name)]
    private static partial Regex Name();

    [GeneratedRegex(RegexTypes.Email)]
    private static partial Regex Email();

    [GeneratedRegex(RegexTypes.Password)]
    private static partial Regex Password();

    [GeneratedRegex(RegexTypes.PasswordHash)]
    private static partial Regex PasswordHash();

    public static bool NameIsMatch<T>(T? value) =>
        RegexExtensions.Name().IsMatch($"{value}");

    public static bool EmailIsMatch<T>(T? value) =>
        RegexExtensions.Email().IsMatch($"{value}");

    public static bool PasswordIsMatch<T>(T? value) =>
        RegexExtensions.Password().IsMatch($"{value}");

    public static bool PasswordHashIsMatch<T>(T? value) =>
        RegexExtensions.PasswordHash().IsMatch($"{value}");
}
