using System.Text.RegularExpressions;
using ECommerceDomain.Constants;

namespace ECommerceDomain.Validations;

public static partial class CustomRegexExtension
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
        CustomRegexExtension.Name().IsMatch($"{value}");

    public static bool EmailIsMatch<T>(T? value) =>
        CustomRegexExtension.Email().IsMatch($"{value}");

    public static bool PasswordIsMatch<T>(T? value) =>
        CustomRegexExtension.Password().IsMatch($"{value}");

    public static bool PasswordHashIsMatch<T>(T? value) =>
        CustomRegexExtension.PasswordHash().IsMatch($"{value}");
}
