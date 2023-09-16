namespace ECommerceDomain.DTOs;

public record CustomerDTO
{
    public string? Id { get; init; }
    public string? Name { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }

    public string? Password { get; init; }
    public string? Role { get; init; }

    public DateTimeOffset? VerifiedOn { get; init; }
    public DateTimeOffset? UpdatedOn { get; init; }
    public DateTimeOffset? CreatedOn { get; init; }
}
