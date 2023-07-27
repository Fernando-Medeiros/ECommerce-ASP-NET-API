using ECommerce_ASP_NET_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_ASP_NET_API.Context;

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
    private static void BCart(ModelBuilder _) { }

    private static void BCategory(ModelBuilder _) { }

    private static void BCustomer(ModelBuilder _) { }

    private static void BProduct(ModelBuilder _) { }

    private static void BSales(ModelBuilder _) { }
    #endregion
}
