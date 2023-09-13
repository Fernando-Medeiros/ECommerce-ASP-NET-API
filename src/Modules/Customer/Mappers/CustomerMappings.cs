using AutoMapper;

namespace ECommerce.Modules.Customer;

public class CustomerMappings : Profile
{
    public CustomerMappings()
    {
        CreateMap<CustomerCreateRequest, CustomerDTO>();

        CreateMap<CustomerUpdateRequest, CustomerDTO>();

        CreateMap<CustomerDomain, CustomerDTO>();

        CreateMap<Context.Models.Customer, CustomerDTO>().ReverseMap();
    }
}
