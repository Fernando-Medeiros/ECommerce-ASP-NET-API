using AutoMapper;
using ECommerce.Events.Mail;
using ECommerce.ModulesHelpers.Crypt;

namespace ECommerce.Modules.Customer;

public class RegisterCustomer
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public RegisterCustomer(
        ICustomerRepository repository,
        ICustomerMailEvent mainEvent,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

        RegisterCustomerEvent += mainEvent.OnRegisterCustomer;
    }

    public async Task Execute(CustomerDTO dto)
    {
        await _repository.UniqueEmailConstraint(dto.Email);

        dto.Password = CryptPassword.Hash(dto.Password!);

        var customerDomain = new CustomerDomain().Register(dto);

        var customerMapped = _mapper.Map<CustomerDTO>(customerDomain);

        await _repository.Register(customerMapped);

        RegisterCustomerEvent.Invoke(this, customerMapped);
    }

    private event EventHandler<CustomerDTO> RegisterCustomerEvent;
}
