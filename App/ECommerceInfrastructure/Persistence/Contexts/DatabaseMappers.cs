using AutoMapper;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Persistence.Models;

namespace ECommerceInfrastructure.Persistence.Contexts;

public class DatabaseMappers : Profile
{
    public DatabaseMappers()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}
