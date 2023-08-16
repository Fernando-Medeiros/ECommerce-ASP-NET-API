using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    #region Tables
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sales> Sales { get; set; }
    #endregion

    #region Override
    override protected void OnModelCreating(ModelBuilder builder)
    {
        DatabaseContext.BAddresses(builder);
        DatabaseContext.BCart(builder);
        DatabaseContext.BCategory(builder);
        DatabaseContext.BCustomer(builder);
        DatabaseContext.BProduct(builder);
        DatabaseContext.BSales(builder);
    }
    #endregion

    #region Private ModelBuilder -> Tables
    private static void BAddresses(ModelBuilder _)
    {
        _.Entity<Address>().HasKey(x => x.Id);

        _.Entity<Address>()
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        _.Entity<Address>()
            .Property(x => x.CustomerId)
            .HasMaxLength(36)
            .IsRequired();

        _.Entity<Address>()
            .Property(x => x.Street)
            .HasMaxLength(100)
            .IsRequired();

        _.Entity<Address>()
            .Property(x => x.ZipCode)
            .HasMaxLength(50)
            .IsRequired();

        _.Entity<Address>()
            .Property(x => x.Type)
            .HasMaxLength(50)
            .IsRequired();

        _.Entity<Address>()
            .Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

        _.Entity<Address>()
            .Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired();

        _.Entity<Address>()
            .Property(x => x.Country)
            .HasMaxLength(50)
            .IsRequired();

        _.Entity<Address>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.Addresses)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }

    private static void BCart(ModelBuilder _)
    {
        _.Entity<Cart>().HasKey(c => c.Id);

        _.Entity<Cart>()
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        _.Entity<Cart>()
            .Property(c => c.CustomerId)
            .HasMaxLength(36)
            .IsRequired();

        _.Entity<Cart>()
            .Property(c => c.ProductId)
            .HasMaxLength(36)
            .IsRequired();

        _.Entity<Cart>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.Carts)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }

    private static void BCategory(ModelBuilder _)
    {
        _.Entity<Category>().HasKey(c => c.Id);

        _.Entity<Category>()
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        _.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        _.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
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
            .Property(c => c.Id)
            .HasMaxLength(36)
            .IsRequired();

        _.Entity<Product>()
            .Property(c => c.CategoryId)
            .HasMaxLength(36)
            .IsRequired();

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
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void BSales(ModelBuilder _)
    {
        _.Entity<Sales>().HasKey(c => c.Id);

        _.Entity<Sales>()
            .Property(c => c.Id)
            .HasMaxLength(36)
            .IsRequired();

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
