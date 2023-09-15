using AutoMapper;
using ECommerceApplication.Requests;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.Mappers;

public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<CreateCustomerRequest, CustomerDTO>();

        CreateMap<UpdateCustomerRequest, CustomerDTO>();

        CreateMap<CustomerEntity, CustomerDTO>()
            .ForMember(d => d.Id, m => m.MapFrom(e => e.Id.Value))
            .ForMember(d => d.Name, m => m.MapFrom(e => e.Name.Name.Value))
            .ForMember(d => d.FirstName, m => m.MapFrom(e => e.Name.FirstName.Value))
            .ForMember(d => d.LastName, m => m.MapFrom(e => e.Name.LastName.Value))
            .ForMember(d => d.Email, m => m.MapFrom(e => e.Email.Value))
            .ForMember(d => d.Password, m => m.MapFrom(e => e.Password.Value))
            .ForMember(d => d.Role, m => m.MapFrom(e => e.Role.Value))
            .ForMember(d => d.CreatedAt, m => m.MapFrom(e => e.CreatedAt))
            .ForMember(d => d.UpdatedAt, m => m.MapFrom(e => e.UpdatedAt))
            .ForMember(d => d.VerifiedAt, m => m.MapFrom(e => e.VerifiedAt));
    }
}
