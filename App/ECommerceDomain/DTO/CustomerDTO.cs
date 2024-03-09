namespace ECommerceDomain.DTO;

public sealed record CustomerDTO(
    string? Id = null,
    string? Name = null,
    string? FirstName = null,
    string? LastName = null,
    string? Email = null,
    string? Password = null,
    string? Role = null,
    DateTimeOffset? VerifiedOn = null,
    DateTimeOffset? UpdatedOn = null,
    DateTimeOffset? CreatedOn = null);
