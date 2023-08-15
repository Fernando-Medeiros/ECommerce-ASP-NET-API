using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.CustomerAddress;

public class AddressUpdateRequest
{
    private string? _street;
    private string? _zipCode;
    private string? _type;
    private string? _city;
    private string? _state;
    private string? _country;

    [Range(1, 99999)]
    public int? Number { get; set; }

    [MinLength(3), MaxLength(100)]
    public string? Street
    {
        get => _street;
        set => _street = value?.Trim().ToLower();
    }

    [DataType(DataType.PostalCode)]
    [MinLength(8), MaxLength(9)]
    public string? ZipCode
    {
        get => _zipCode;
        set => _zipCode = value?.Trim().ToLower();
    }

    [MinLength(3), MaxLength(50)]
    public string? Type
    {
        get => _type;
        set => _type = value?.Trim().ToLower();
    }

    [MinLength(3), MaxLength(50)]
    public string? City
    {
        get => _city;
        set => _city = value?.Trim().ToLower();
    }

    [MinLength(3), MaxLength(50)]
    public string? State
    {
        get => _state;
        set => _state = value?.Trim().ToLower();
    }

    [MinLength(3), MaxLength(50)]
    public string? Country
    {
        get => _country;
        set => _country = value?.Trim().ToLower();
    }
}
