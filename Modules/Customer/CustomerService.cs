namespace ECommerce_ASP_NET_API.Modules.Customer;

using AutoMapper;
using BCrypt.Net;
using ECommerce_ASP_NET_API.Models;
using ECommerce_ASP_NET_API.Exceptions;
using ECommerce_ASP_NET_API.Modules.Cart;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    public CustomerService(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CartDTO>> FindCarts(string id)
    {
        var carts = await _repository.FindCarts(id);

        return _mapper.Map<IEnumerable<CartDTO>>(carts);
    }

    public async Task<CustomerDTO> FindById(string id)
    {
        var customerEntity = await _repository.Find(id);

        return _mapper.Map<CustomerDTO>(customerEntity);
    }

    public async Task<CustomerDTO> Register(CustomerDTO Dto)
    {
        if (await _repository.Find(email: Dto.Email) != null)
            throw new BadRequestError("Email is already in use");

        Dto.Id = Guid.NewGuid().ToString();

        Dto.CreatedAt = DateTime.UtcNow;

        Dto.Password = BCrypt.HashPassword(Dto.Password);

        var customerEntity = _mapper.Map<Customer>(Dto);

        await _repository.Create(customerEntity);

        return _mapper.Map<CustomerDTO>(customerEntity);
    }

    public async Task Update(CustomerDTO Dto)
    {
        var customerEntity = await _repository.Find(id: Dto.Id)
            ?? throw new NotFoundError("Customer Not Found"); ;

        if (Dto.Name != null)
            customerEntity.Name = Dto.Name;

        if (Dto.FirstName != null)
            customerEntity.FirstName = Dto.FirstName;

        if (Dto.LastName != null)
            customerEntity.LastName = Dto.LastName;

        if (Dto.Email != null)
        {
            if (await _repository.Find(email: Dto.Email) != null)
                throw new BadRequestError("Email is already in use");

            customerEntity.Email = Dto.Email;
        }

        await _repository.Update(customerEntity);
    }

    public async Task Remove(CustomerDTO Dto)
    {
        var customerEntity = await _repository.Find(id: Dto.Id)
            ?? throw new NotFoundError("Customer Not Found");

        await _repository.Remove(customerEntity);
    }
}
