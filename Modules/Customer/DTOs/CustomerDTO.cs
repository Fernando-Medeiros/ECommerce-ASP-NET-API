namespace ECommerce_ASP_NET_API.Modules.Customer.DTOs;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ECommerce_ASP_NET_API.Models;

public class CustomerDTO
{
    public virtual string? Id { get; set; }

    [MinLength(3), MaxLength(50)]
    public virtual string? Name { get; set; }

    [MinLength(3), MaxLength(50)]
    public virtual string? FirstName { get; set; }

    [MinLength(3), MaxLength(50)]
    public virtual string? LastName { get; set; }

    [MinLength(11), MaxLength(150)]
    public virtual string? Email { get; set; }

    [MinLength(8), MaxLength(255)]
    public virtual string? Password { get; set; }

    public virtual DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public ICollection<Cart>? Carts { get; set; }
}