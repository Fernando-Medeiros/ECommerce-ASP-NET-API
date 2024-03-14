using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Model;

public class Address
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }
    public string? Code { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Street { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public DateTimeOffset CreatedOn { get; set; }


    public Customer? Customer { get; set; }

    internal static void Builder(ModelBuilder x)
    {
        x.Entity<Address>().HasKey(x => x.Id);

        x.Entity<Address>()
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Address>()
            .Property(x => x.CustomerId)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Address>()
            .Property(x => x.Street)
            .HasMaxLength(100)
            .IsRequired();

        x.Entity<Address>()
            .Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<Address>()
            .Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<Address>()
            .Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<Address>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.Addresses)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}