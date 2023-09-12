using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public partial class DatabaseContext
{
    private static void CartModelBuilder(ModelBuilder x)
    {
        x.Entity<Cart>().HasKey(c => c.Id);

        x.Entity<Cart>()
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Cart>()
            .Property(c => c.CustomerId)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Cart>()
            .Property(c => c.ProductId)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Cart>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.Carts)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}
