
using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public partial class DatabaseContext
{
    public static void SalesModelBuilder(ModelBuilder x)
    {
        x.Entity<Sales>().HasKey(c => c.Id);

        x.Entity<Sales>()
            .Property(c => c.Id)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Sales>()
            .Property(c => c.CustomerId)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Sales>()
            .Property(c => c.ProductId)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Sales>()
            .Property(c => c.Price)
            .HasPrecision(12, 2);
    }
}
