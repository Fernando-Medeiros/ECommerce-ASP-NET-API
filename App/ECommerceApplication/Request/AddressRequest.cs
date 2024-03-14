using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public sealed record AddressRequest
{
    private string? _code;
    private string? _city;
    private string? _state;
    private string? _street;

    public string? Code { get => _code; set => _code ??= value?.Trim(); }
    public string? City { get => _city; set => _city ??= value?.Trim(); }
    public string? State { get => _state; set => _state ??= value?.Trim(); }
    public string? Street { get => _street; set => _street ??= value?.Trim(); }

    public async Task ValidateAsync(bool required = true) => await Task.WhenAll(
    Task.Run(() =>
    {
        new CustomValidation<string?>(Code, nameof(Code), required)
            .NotNull()
            .NotEmpty()
            .Length(8, 50);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(City, nameof(City), required)
            .NotNull()
            .NotEmpty()
            .Length(2, 50);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(State, nameof(State), required)
            .NotNull()
            .NotEmpty()
            .Length(2, 50);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(Street, nameof(Street), required)
            .NotNull()
            .NotEmpty()
            .Length(2, 100);
    })
    );
}