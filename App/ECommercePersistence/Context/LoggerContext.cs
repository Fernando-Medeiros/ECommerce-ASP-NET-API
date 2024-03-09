using ECommercePersistence.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Context;

public class LoggerContext(
    DbContextOptions<LoggerContext> options) : DbContext(options)
{
    public DbSet<LogRequest> LogRequests { get; set; }
    public DbSet<LogResponse> LogResponses { get; set; }

    override protected void OnModelCreating(ModelBuilder builder)
    {
        LogRequest.Builder(builder);
        LogResponse.Builder(builder);
    }
}
