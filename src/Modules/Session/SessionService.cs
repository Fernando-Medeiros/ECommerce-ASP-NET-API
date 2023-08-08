namespace ECommerce.Modules.Session;

using AutoMapper;
using BCrypt.Net;
using ECommerce.Exceptions;
using ECommerce.Modules.Customer;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _repository;
    private readonly IMapper _mapper;
    public SessionService(ISessionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerDTO> FindCustomer(SignInDTO signInDto)
    {
        var customerEntity = await _repository.FindCustomer(signInDto.Email!);

        if (customerEntity != null)
        {
            if (BCrypt.Verify(signInDto.Password, customerEntity!.Password) is false)
                throw new UnauthorizedError("Email or Password invalid");
        }

        return _mapper.Map<CustomerDTO>(customerEntity);
    }
}
