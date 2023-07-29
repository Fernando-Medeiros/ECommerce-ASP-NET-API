namespace ECommerce_ASP_NET_API.Modules.Customer;

using AutoMapper;
using BCrypt.Net;
using ECommerce_ASP_NET_API.Modules.Customer.Contracts;
using ECommerce_ASP_NET_API.Modules.Customer.DTOs;
using ECommerce_ASP_NET_API.Models;


public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    public CustomerService(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerDTO> FindById(string id)
    {
        var customerEntity = await _repository.FindById(id);

        return _mapper.Map<CustomerDTO>(customerEntity);
    }

    public async Task<CustomerDTO> Register(CustomerDTO customerDto)
    {
        customerDto.Id = Guid.NewGuid().ToString();

        customerDto.CreatedAt = DateTime.UtcNow;

        customerDto.Password = BCrypt.HashPassword(customerDto.Password);

        var customerEntity = _mapper.Map<Customer>(customerDto);

        await _repository.Create(customerEntity);

        return customerDto;
    }

    public async Task Update(CustomerDTO customerDto)
    {
        var customer = await FindById(customerDto.Id!);

        customer.Name = String.IsNullOrEmpty(customerDto.Name)
            ? customer.Name
            : customerDto.Name;

        customer.FirstName = String.IsNullOrEmpty(customerDto.FirstName)
            ? customer.FirstName
            : customerDto.FirstName;

        customer.LastName = String.IsNullOrEmpty(customerDto.LastName)
            ? customer.LastName
            : customerDto.LastName;

        customer.Email = String.IsNullOrEmpty(customerDto.Email)
            ? customer.Email
            : customerDto.Email;

        var customerEntity = _mapper.Map<Customer>(customer);

        await _repository.Update(customerEntity);
    }

    public async Task Remove(CustomerDTO customerDto)
    {
        var customerEntity = _mapper.Map<Customer>(customerDto);

        await _repository.Remove(customerEntity);
    }
}
