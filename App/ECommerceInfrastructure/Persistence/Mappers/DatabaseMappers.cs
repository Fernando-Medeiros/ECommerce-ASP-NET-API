using AutoMapper;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Persistence.Models;

namespace ECommerceInfrastructure.Persistence.Mappers;

public class DatabaseMappers : Profile
{
    public DatabaseMappers()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}
