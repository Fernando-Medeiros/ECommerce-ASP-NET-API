using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public partial class DatabaseContext
{
    public static void ProductModelBuilder(ModelBuilder x)
    {
        x.Entity<Product>().HasKey(c => c.Id);

        x.Entity<Product>()
            .Property(c => c.Id)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Product>()
            .Property(c => c.CategoryId)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Product>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        x.Entity<Product>()
            .Property(c => c.Description)
            .HasMaxLength(255)
            .IsRequired();

        x.Entity<Product>()
            .Property(c => c.ImageURL)
            .HasMaxLength(255)
            .IsRequired();

        x.Entity<Product>()
            .Property(c => c.Price)
            .HasPrecision(12, 2);

        x.Entity<Product>()
            .HasMany(c => c.Carts)
            .WithOne(c => c.Product)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
