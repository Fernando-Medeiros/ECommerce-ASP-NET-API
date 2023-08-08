namespace ECommerce.Models;

public class Address
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }
    public int Number { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
    public string? Type { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public DateTime CreatedAt { get; set; }
    public Customer? Customer { get; set; }
}
