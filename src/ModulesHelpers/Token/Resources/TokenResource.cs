namespace ECommerce.ModulesHelpers.Token;

public readonly struct TokenResource
{
    public readonly string Token { get; init; }
    public readonly string Type { get; init; }
    public readonly string Scope { get; init; }

    public TokenResource(TokenDTO _)
    {
        Token = _.Token;
        Type = Enum.GetName(_.Type)!;
        Scope = Enum.GetName(_.Scope)!;
    }
}