using ECommerceDomain.Enums;

namespace ECommerceDomain.DTO;

public sealed record TokenDTO(
    string Value,
    ETokenType Type,
    ETokenScope Scope);
