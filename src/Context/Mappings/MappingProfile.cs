using AutoMapper;
using ECommerce.Modules.Customer;
using ECommerce.Modules.CustomerCart;
using ECommerce.Modules.CustomerAddress;
using ECommerce.Modules.Product;
using ECommerce.Modules.ProductCategory;
using ECommerce.Modules.Sales;
using ECommerce.Context.Models;

namespace ECommerce.Context.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<Address, AddressCreateDTO>().ReverseMap();

        CreateMap<Cart, CartDTO>().ReverseMap();
        CreateMap<Cart, CartCreateDTO>().ReverseMap();

        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Category, CategoryCreateDTO>().ReverseMap();

        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<CustomerDomain, CustomerDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductCreateDTO>().ReverseMap();

        CreateMap<Sales, SalesDTO>().ReverseMap();
        CreateMap<Sales, SalesCreateDTO>().ReverseMap();
    }
}
