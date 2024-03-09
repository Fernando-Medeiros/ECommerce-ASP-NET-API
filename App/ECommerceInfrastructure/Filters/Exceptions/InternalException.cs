using ECommerceCommon;

namespace ECommerceInfrastructure.Filters.Exceptions;

public sealed class InternalException(
    string message,
    List<string> details)
    : CustomException(
        code: 500,
        error: nameof(InternalException),
        message: message,
        details: details);
