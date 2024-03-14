using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Model;

public class Customer
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public DateTimeOffset? VerifiedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public DateTimeOffset CreatedOn { get; set; }


    [JsonIgnore]
    public ICollection<Address>? Addresses { get; set; }

    internal static void Builder(ModelBuilder x)
    {
        x.Entity<Customer>().HasKey(c => c.Id);

        x.Entity<Customer>()
            .Property(c => c.Id)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Customer>()
            .Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<Customer>()
            .Property(c => c.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<Customer>()
            .Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<Customer>()
            .Property(c => c.Email)
            .HasMaxLength(150)
            .IsRequired();

        x.Entity<Customer>()
            .Property(c => c.Password)
            .HasMaxLength(255)
            .IsRequired();

        x.Entity<Customer>()
            .Property(c => c.Role)
            .HasMaxLength(50)
            .IsRequired();


        x.Entity<Customer>()
            .HasIndex(c => c.Id)
            .IsUnique();

        x.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();

        x.Entity<Customer>()
            .HasIndex(c => c.Role);
    }
}