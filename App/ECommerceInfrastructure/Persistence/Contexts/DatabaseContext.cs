using ECommerceInfrastructure.Persistence.Models;
using ECommerceInfrastructure.Persistence.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Persistence.Contexts;

public class DatabaseContext : DbContext
{
    public DatabaseContext(
        DbContextOptions<DatabaseContext> options) : base(options) { }

    #region Tables
    public DbSet<Customer> Customers { get; set; }
    #endregion

    #region Override
    override protected void OnModelCreating(ModelBuilder builder)
    {
        CustomerConfiguration.Builder(builder);
    }
    #endregion
}