namespace ECommerce.ModulesHelpers.Token;

public readonly struct TokenDTO
{
    public readonly string Token { get; init; }
    public readonly string Type { get; init; }

    public TokenDTO(string token, string type)
    {
        Token = token;
        Type = type;
    }
}
