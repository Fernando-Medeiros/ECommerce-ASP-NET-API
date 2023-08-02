namespace ECommerce_ASP_NET_API.Modules.Sales;

using AutoMapper;
using ECommerce_ASP_NET_API.Exceptions;
using ECommerce_ASP_NET_API.Models;
using ECommerce_ASP_NET_API.Modules.Customer;
using ECommerce_ASP_NET_API.Modules.Product;

public class SalesService : ISalesService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly ISalesRepository _repository;
    private readonly IMapper _mapper;
    public SalesService(
        ICustomerRepository customerRepository,
        IProductRepository productRepository,
        ISalesRepository repository,
        IMapper mapper)
    {
        _customerRepository = customerRepository; ;
        _productRepository = productRepository; ;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SalesDTO> Find(int? id)
    {
        var sales = await _repository.Find(id);

        return _mapper.Map<SalesDTO>(sales);
    }

    public async Task Register(SalesDTO Dto)
    {
        _ = await _customerRepository.Find(id: Dto.CustomerId)
            ?? throw new NotFoundError("Customer Not Found");

        _ = await _productRepository.FindOne(id: Dto.ProductId)
            ?? throw new NotFoundError("Product Not Found");

        Dto.CreatedAt = DateTime.UtcNow;

        var salesEntity = _mapper.Map<Sales>(Dto);

        await _repository.Create(salesEntity);
    }

    public async Task Remove(SalesDTO Dto)
    {
        var salesEntity = await _repository.Find(Dto.Id)
            ?? throw new NotFoundError("Sales Not Found");

        await _repository.Remove(salesEntity);
    }
}
