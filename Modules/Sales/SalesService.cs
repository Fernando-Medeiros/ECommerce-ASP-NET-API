namespace ECommerce.Modules.Sales;

using AutoMapper;
using ECommerce.Exceptions;
using ECommerce.Models;
using ECommerce.Modules.Customer;
using ECommerce.Modules.Product;

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

    public async Task<SalesDTO> Find(int id)
    {
        var salesEntity = await _repository.Find(id)
            ?? throw new NotFoundError("Sales Not Found");

        return _mapper.Map<SalesDTO>(salesEntity);
    }

    public async Task Register(SalesDTO dto)
    {
        _ = await _customerRepository.Find(id: dto.CustomerId)
            ?? throw new NotFoundError("Customer Not Found");

        _ = await _productRepository.FindOne(id: dto.ProductId)
            ?? throw new NotFoundError("Product Not Found");

        dto.CreatedAt = DateTime.UtcNow;

        var salesEntity = _mapper.Map<Sales>(dto);

        await _repository.Register(salesEntity);
    }

    public async Task Remove(SalesDTO dto)
    {
        SalesDTO sales = await Find((int)dto.Id!);

        var salesEntity = _mapper.Map<Sales>(sales);

        await _repository.Remove(salesEntity);
    }
}
