using System.ComponentModel.DataAnnotations;

namespace ECommerce_ASP_NET_API.Modules.Customer;

public class CustomerQueryDTO
{
    [Required(ErrorMessage = "The Id is Required")]
    [MinLength(36)]
    [MaxLength(36)]
    public string? Id { get; set; }
}
