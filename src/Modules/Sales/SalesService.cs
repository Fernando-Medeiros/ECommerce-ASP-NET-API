namespace ECommerce.Modules.Sales;

using System.Collections.Generic;
using AutoMapper;
using ECommerce.Exceptions;
using ECommerce.Models;
using ECommerce.Modules.Customer;
using ECommerce.Modules.Product;
using ECommerce.Modules.Sales.DTOs;

public class SalesService : ISalesService
{
    private readonly ICustomerRepository _customerRepository;

    private readonly IProductRepository _productRepository;

    private readonly ISalesRepository _salesRepository;

    private readonly IMapper _mapper;

    public SalesService(
        ICustomerRepository customerRepository,
        IProductRepository productRepository,
        ISalesRepository salesRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository; ;
        _productRepository = productRepository; ;
        _salesRepository = salesRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SalesDTO>> FindMany(SalesQueryDTO query)
    {
        var salesEntities = await _salesRepository.FindMany(query);

        return _mapper.Map<IEnumerable<SalesDTO>>(salesEntities);
    }

    public async Task<SalesDTO> FindOne(SalesQueryFindOneDTO query)
    {
        var salesEntity = await _salesRepository.FindOne(query)
            ?? throw new NotFoundError("Sales Not Found");

        return _mapper.Map<SalesDTO>(salesEntity);
    }

    public async Task<SalesDTO> FindById(string id)
    {
        var salesEntity = await _salesRepository.FindById(id)
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

        await _salesRepository.Register(salesEntity);
    }

    public async Task Remove(SalesDTO dto)
    {
        SalesDTO sales = await FindById((string)dto.Id!);

        var salesEntity = _mapper.Map<Sales>(sales);

        await _salesRepository.Remove(salesEntity);
    }
}
