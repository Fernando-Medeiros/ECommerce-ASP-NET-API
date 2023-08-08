namespace ECommerce.Modules.Customer;

using AutoMapper;
using BCrypt.Net;
using ECommerce.Models;
using ECommerce.Exceptions;
using ECommerce.Modules.Cart;

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
        var customerEntity = await _repository.Find(id)
            ?? throw new NotFoundError("Customer Not Found");

        return _mapper.Map<CustomerDTO>(customerEntity);
    }

    public async Task Register(CustomerDTO dto)
    {
        await EmailExists(dto.Email);

        dto.Id = Guid.NewGuid().ToString();

        dto.CreatedAt = DateTime.UtcNow;

        dto.Password = BCrypt.HashPassword(dto.Password);

        var customerEntity = _mapper.Map<Customer>(dto);

        await _repository.Create(customerEntity);
    }

    public async Task Update(CustomerDTO dto)
    {
        CustomerDTO customer = await FindById(dto.Id!);

        if (dto.Email != null)
        {
            await EmailExists(dto.Email);

            customer.Email = dto.Email;
        }

        if (dto.Name != null)
            customer.Name = dto.Name;

        if (dto.FirstName != null)
            customer.FirstName = dto.FirstName;

        if (dto.LastName != null)
            customer.LastName = dto.LastName;

        var customerEntity = _mapper.Map<Customer>(customer);

        await _repository.Update(customerEntity);
    }

    public async Task Remove(CustomerDTO dto)
    {
        CustomerDTO customer = await FindById(dto.Id!);

        var customerEntity = _mapper.Map<Customer>(customer);

        await _repository.Remove(customerEntity);
    }

    private async Task EmailExists(string? email)
    {
        if (await _repository.Find(email: email) != null)
            throw new BadRequestError("Email is already in use");
    }
}
