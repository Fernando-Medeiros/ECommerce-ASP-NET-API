using ECommercePersistence.Models;
using ECommercePersistence.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Contexts;

public class LoggerContext : DbContext
{
    public LoggerContext(
        DbContextOptions<LoggerContext> options) : base(options) { }

    public DbSet<LogRequest> LogRequests { get; set; }
    public DbSet<LogResponse> LogResponses { get; set; }

    override protected void OnModelCreating(ModelBuilder builder)
    {
        LogRequestConfiguration.Builder(builder);
        LogResponseConfiguration.Builder(builder);
    }
}
