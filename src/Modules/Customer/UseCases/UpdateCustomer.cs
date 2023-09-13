using AutoMapper;

namespace ECommerce.Modules.Customer;

public class UpdateCustomer
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCustomer(
        ICustomerRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Execute(CustomerDTO dto)
    {
        var currentCustomer = await _repository
            .FindOneOrNotFound(new() { Id = dto.Id });

        if (dto.Email != currentCustomer.Email)
            await _repository.UniqueEmailConstraint(dto.Email);

        var customerDomain = new CustomerDomain()
            .LoadState(currentCustomer)
            .Update(dto);

        var customerMapped = _mapper.Map<CustomerDTO>(customerDomain);

        await _repository.Update(customerMapped);
    }
}
