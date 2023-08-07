namespace ECommerce.Modules.Customer;

using System.Text.Json.Serialization;
using ECommerce.Models;

public class CustomerDTO
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    [JsonIgnore]
    public string? Password { get; set; }

    public DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public string? Role { get; set; }

    [JsonIgnore]
    public ICollection<Cart>? Carts { get; set; }
}