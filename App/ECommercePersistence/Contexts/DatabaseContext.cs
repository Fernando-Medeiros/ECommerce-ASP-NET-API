using ECommercePersistence.Models;
using ECommercePersistence.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Contexts;

public class DatabaseContext : DbContext
{
    public DatabaseContext(
        DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    override protected void OnModelCreating(ModelBuilder builder)
    {
        CustomerConfiguration.Builder(builder);
    }
}