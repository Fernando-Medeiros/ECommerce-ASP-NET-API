
using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public partial class DatabaseContext
{
    public static void CategoryModelBuilder(ModelBuilder x)
    {
        x.Entity<Category>().HasKey(c => c.Id);

        x.Entity<Category>()
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        x.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        x.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
