using AutoMapper;
using ECommerce_ASP_NET_API.Modules.Cart;
using ECommerce_ASP_NET_API.Modules.Category;
using ECommerce_ASP_NET_API.Modules.Customer;
using ECommerce_ASP_NET_API.Modules.Product;
using ECommerce_ASP_NET_API.Modules.Sales.DTOs;

namespace ECommerce_ASP_NET_API.Models.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cart, CartDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Sales, SalesDTO>().ReverseMap();
    }
}
