namespace ECommerceInfrastructure.Persistence.Models;

public class LogResponse
{
    public long? Id { get; set; }
    public string? Scheme { get; set; }
    public string? HttpMethod { get; set; }
    public string? Controller { get; set; }
    public string? Action { get; set; }
    public string? Path { get; set; }
    public int? StatusCode { get; set; }
    public DateTime CreatedOn { get; set; }
}
