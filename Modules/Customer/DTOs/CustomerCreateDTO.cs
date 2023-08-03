using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.Modules.Customer;

public class CustomerCreateDTO : CustomerDTO
{
    [JsonIgnore]
    public override string? Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    public override string? Name { get; set; }

    [Required(ErrorMessage = "The FirstName is Required")]
    public override string? FirstName { get; set; }

    [Required(ErrorMessage = "The LastName is Required")]
    public override string? LastName { get; set; }

    [Required(ErrorMessage = "The Email is Required")]
    public override string? Email { get; set; }

    [Required(ErrorMessage = "The Password is Required")]
    public override string? Password { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
