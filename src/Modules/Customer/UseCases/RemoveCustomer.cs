namespace ECommerce.Modules.Customer;

public class RemoveCustomer
{
    private readonly ICustomerRepository _repository;

    public RemoveCustomer(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(CustomerDTO dto)
    {
        var customerDto = await _repository.FindOneOrNotFound(dto);

        await _repository.Remove(customerDto);
    }
}
