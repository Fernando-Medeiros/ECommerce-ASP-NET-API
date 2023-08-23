using AutoMapper;
using ECommerce.Modules.Category;
using ECommerce.Modules.Customer;
using ECommerce.Modules.CustomerCart;
using ECommerce.Modules.CustomerAddress;
using ECommerce.Modules.Product;
using ECommerce.Modules.Sales;

namespace ECommerce.Models.Mappings;

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
        CreateMap<Customer, CustomerCreateDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductCreateDTO>().ReverseMap();

        CreateMap<Sales, SalesDTO>().ReverseMap();
        CreateMap<Sales, SalesCreateDTO>().ReverseMap();
    }
}
