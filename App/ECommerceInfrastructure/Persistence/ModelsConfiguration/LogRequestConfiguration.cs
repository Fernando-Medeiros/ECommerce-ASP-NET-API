using ECommerceInfrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Persistence.ModelsConfiguration;

public static class LogRequestConfiguration
{
    public static void Builder(ModelBuilder x)
    {
        x.Entity<LogRequest>().HasKey(e => e.Id);

        x.Entity<LogRequest>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        x.Entity<LogRequest>()
            .Property(e => e.Scheme)
            .HasMaxLength(15)
            .IsRequired();

        x.Entity<LogRequest>()
            .Property(e => e.HttpMethod)
            .HasMaxLength(15)
            .IsRequired();

        x.Entity<LogRequest>()
            .Property(e => e.Controller)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<LogRequest>()
            .Property(e => e.Action)
            .HasMaxLength(50)
            .IsRequired();

        x.Entity<LogRequest>()
            .Property(e => e.Path)
            .HasMaxLength(100)
            .IsRequired();

        x.Entity<LogRequest>().Property(e => e.CreatedOn).IsRequired();


        x.Entity<LogRequest>()
            .HasIndex(e => e.Controller);

        x.Entity<LogRequest>()
            .HasIndex(e => e.Action);
    }
}