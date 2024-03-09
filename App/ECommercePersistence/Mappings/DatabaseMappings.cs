using AutoMapper;
using ECommerceDomain.DTO;
using ECommercePersistence.Models;

namespace ECommercePersistence.Mappings;

public class DatabaseMappings : Profile
{
    public DatabaseMappings()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}
