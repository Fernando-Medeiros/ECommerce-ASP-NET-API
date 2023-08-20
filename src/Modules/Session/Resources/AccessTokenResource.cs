namespace ECommerce.Modules.Session;

public readonly struct AccessTokenResource
{
    public readonly string AccessToken { get; init; }
    public readonly string Type { get; init; }

    public AccessTokenResource(TokenDTO _)
    {
        AccessToken = _.Token;
        Type = _.Type;
    }
}