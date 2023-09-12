namespace ECommerce.Modules.Customer;

public class FindOneCustomer
{
    private readonly ICustomerRepository _repository;

    public FindOneCustomer(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDTO> Execute(CustomerDTO dto)
    {
        return await _repository.FindOneOrNotFound(dto);
    }
}
