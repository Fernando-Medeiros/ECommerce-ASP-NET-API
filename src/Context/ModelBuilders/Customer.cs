using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public partial class DatabaseContext
{
    private static void CustomerModelBuilder(ModelBuilder x)
    {
        x.Entity<Customer>().HasKey(c => c.Id);

        x.Entity<Customer>()
            .Property(c => c.Id)
            .HasMaxLength(36);

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
            .HasMaxLength(50);
    }
}
