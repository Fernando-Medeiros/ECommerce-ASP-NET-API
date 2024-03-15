using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public sealed record IdentityRequest
{
    private string? _id;

    public string? Id { get => _id; set => _id ??= value?.Trim(); }

    public async Task ValidateAsync() => await Task.Run(() =>
    {
        new CustomValidation<string?>(Id, nameof(Id))
            .NotNull()
            .NotEmpty()
            .Length(36, 36);
    });
}