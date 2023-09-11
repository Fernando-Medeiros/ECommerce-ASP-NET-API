using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public partial class DatabaseContext
{
    public static void AddressModelBuilder(ModelBuilder x)
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
            .Property(x => x.ZipCode)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<Address>()
            .Property(x => x.Type)
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
            .Property(x => x.Country)
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
