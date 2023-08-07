using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    #region Tables
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sales> Sales { get; set; }
    #endregion

    #region Override
    override protected void OnModelCreating(ModelBuilder builder)
    {
        DatabaseContext.BCart(builder);
        DatabaseContext.BCategory(builder);
        DatabaseContext.BCustomer(builder);
        DatabaseContext.BProduct(builder);
        DatabaseContext.BSales(builder);
    }
    #endregion

    #region Private ModelBuilder -> Tables
    private static void BCart(ModelBuilder _)
    {
        _.Entity<Cart>().HasKey(c => c.Id);

        _.Entity<Cart>()
        .Property(c => c.ProductId)
        .HasMaxLength(36)
        .IsRequired();

        _.Entity<Cart>()
        .HasOne(c => c.Customer)
        .WithMany(c => c.Carts)
        .OnDelete(DeleteBehavior.NoAction)
        .IsRequired();
    }

    private static void BCategory(ModelBuilder _)
    {
        _.Entity<Category>().HasKey(c => c.Id);

        _.Entity<Category>()
        .Property(c => c.Name)
        .HasMaxLength(100)
        .IsRequired();

        _.Entity<Category>()
        .HasMany(c => c.Products)
        .WithOne(c => c.Category)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired();
    }

    private static void BCustomer(ModelBuilder _)
    {
        _.Entity<Customer>().HasKey(c => c.Id);

        _.Entity<Customer>()
        .Property(c => c.Id)
        .HasMaxLength(36);

        _.Entity<Customer>()
        .Property(c => c.Name)
        .HasMaxLength(50)
        .IsRequired();

        _.Entity<Customer>()
        .Property(c => c.FirstName)
        .HasMaxLength(50)
        .IsRequired();

        _.Entity<Customer>()
        .Property(c => c.LastName)
        .HasMaxLength(50)
        .IsRequired();

        _.Entity<Customer>()
        .Property(c => c.Email)
        .HasMaxLength(150)
        .IsRequired();

        _.Entity<Customer>()
        .Property(c => c.Password)
        .HasMaxLength(255)
        .IsRequired();

        _.Entity<Customer>()
        .Property(c => c.Role)
        .HasMaxLength(50);
    }

    private static void BProduct(ModelBuilder _)
    {
        _.Entity<Product>().HasKey(c => c.Id);

        _.Entity<Product>()
        .Property(c => c.Name)
        .HasMaxLength(100)
        .IsRequired();

        _.Entity<Product>()
        .Property(c => c.Description)
        .HasMaxLength(255)
        .IsRequired();

        _.Entity<Product>()
        .Property(c => c.ImageURL)
        .HasMaxLength(255)
        .IsRequired();

        _.Entity<Product>()
        .Property(c => c.Price)
        .HasPrecision(12, 2);

        _.Entity<Product>()
        .HasMany(c => c.Carts)
        .WithOne(c => c.Product)
        .OnDelete(DeleteBehavior.Cascade);
    }

    private static void BSales(ModelBuilder _)
    {
        _.Entity<Sales>().HasKey(c => c.Id);

        _.Entity<Sales>()
        .Property(c => c.CustomerId)
        .HasMaxLength(36)
        .IsRequired();

        _.Entity<Sales>()
        .Property(c => c.ProductId)
        .HasMaxLength(36)
        .IsRequired();

        _.Entity<Sales>()
        .Property(c => c.Price)
        .HasPrecision(12, 2);
    }
    #endregion
}
