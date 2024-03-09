using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Model;

public class LogResponse
{
    public long? Id { get; set; }
    public string? Scheme { get; set; }
    public string? HttpMethod { get; set; }
    public string? Controller { get; set; }
    public string? Action { get; set; }
    public string? Path { get; set; }
    public int? StatusCode { get; set; }
    public DateTime CreatedOn { get; set; }

    internal static void Builder(ModelBuilder x)
    {
        x.Entity<LogResponse>().HasKey(e => e.Id);

        x.Entity<LogResponse>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        x.Entity<LogResponse>()
            .Property(e => e.Scheme)
            .HasMaxLength(15)
            .IsRequired();

        x.Entity<LogResponse>()
            .Property(e => e.HttpMethod)
            .HasMaxLength(15)
            .IsRequired();

        x.Entity<LogResponse>()
            .Property(e => e.Controller)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<LogResponse>()
            .Property(e => e.Action)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<LogResponse>()
            .Property(e => e.Path)
            .HasMaxLength(100)
            .IsRequired();

        x.Entity<LogResponse>().Property(e => e.StatusCode).IsRequired();

        x.Entity<LogResponse>().Property(e => e.CreatedOn).IsRequired();


        x.Entity<LogResponse>()
            .HasIndex(e => e.Controller);

        x.Entity<LogResponse>()
            .HasIndex(e => e.Action);
    }
}
