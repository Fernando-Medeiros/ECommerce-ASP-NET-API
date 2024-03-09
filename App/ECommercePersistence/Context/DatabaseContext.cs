using AutoMapper;
using ECommerceDomain.DTO;
using ECommercePersistence.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Context;

public sealed class DatabaseContext(
    DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    override protected void OnModelCreating(ModelBuilder builder)
    {
        Customer.Builder(builder);
    }
}

public sealed class DatabaseMapping : Profile
{
    public DatabaseMapping()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}