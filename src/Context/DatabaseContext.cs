using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Context;

public partial class DatabaseContext : DbContext
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
        AddressModelBuilder(builder);
        CartModelBuilder(builder);
        CategoryModelBuilder(builder);
        CustomerModelBuilder(builder);
        ProductModelBuilder(builder);
        SalesModelBuilder(builder);
    }
    #endregion
}
