namespace ECommerceDomain.DTO;

public sealed record AddressDTO(
    string? Id = null,
    string? CustomerId = null,
    string? Code = null,
    string? City = null,
    string? State = null,
    string? Street = null,
    DateTimeOffset? UpdatedOn = null,
    DateTimeOffset? CreatedOn = null);