namespace ECommerce.Modules.Sales;

using ECommerce.Exceptions;
using ECommerce.Modules.Customer;
using ECommerce.Modules.Product;

public class SalesService : ISalesService
{
    private readonly ICustomerRepository _customerRepository;

    private readonly IProductRepository _productRepository;

    private readonly ISalesRepository _salesRepository;

    public SalesService(
        ICustomerRepository customerRepository,
        IProductRepository productRepository,
        ISalesRepository salesRepository)
    {
        _customerRepository = customerRepository; ;
        _productRepository = productRepository; ;
        _salesRepository = salesRepository;

    }

    public async Task<IEnumerable<SalesDTO?>> FindMany(SalesQueryDTO query)
    {
        return await _salesRepository.FindMany(query);
    }

    public async Task<SalesDTO> FindById(string id)
    {
        return await _salesRepository.FindById(id)
            ?? throw new NotFoundError("Sales Not Found");
    }

    public async Task Register(SalesCreateDTO dto)
    {
        _ = await _customerRepository.Find(id: dto.CustomerId)
            ?? throw new NotFoundError("Customer Not Found");

        _ = await _productRepository.FindOne(id: dto.ProductId)
            ?? throw new NotFoundError("Product Not Found");

        await _salesRepository.Register(dto);
    }

    public async Task Remove(string id)
    {
        SalesDTO sales = await FindById(id);

        await _salesRepository.Remove(sales);
    }
}
