using AutoMapper;
using ECommerce.Modules.Cart;
using ECommerce.Modules.Category;
using ECommerce.Modules.Customer;
using ECommerce.Modules.Product;
using ECommerce.Modules.Sales;

namespace ECommerce.Models.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cart, CartDTO>().ReverseMap();

        CreateMap<Category, CategoryDTO>().ReverseMap();

        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<Customer, CustomerCreateDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();

        CreateMap<Sales, SalesDTO>().ReverseMap();
    }
}
