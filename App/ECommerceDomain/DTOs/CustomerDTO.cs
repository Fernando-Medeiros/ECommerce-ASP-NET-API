namespace ECommerceDomain.DTOs;

public record CustomerDTO()
{
    public string? Id { get; init; }
    public string? Name { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }

    public string? Password { get; init; }
    public string? Role { get; init; }

    public DateTimeOffset? VerifiedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
    public DateTimeOffset? CreatedAt { get; init; }
}
