using System.Text.Json.Serialization;

namespace ECommerce_ASP_NET_API.Modules.Customer.DTOs;

public class CustomerUpdateDTO : CustomerDTO
{
    [JsonIgnore]
    public override string? Id { get; set; }

    [JsonIgnore]
    public override string? Password { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
