namespace ECommerce_ASP_NET_API.Modules.Session;

using ECommerce_ASP_NET_API.Exceptions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/", Name = "Session")]
public class SessionController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly ISessionService _sessionService;
    public SessionController(
        ISessionService sessionService,
        TokenService tokenService)
    {
        _sessionService = sessionService;
        _tokenService = tokenService;
    }

    [HttpPost("signin")]
    public async Task<ActionResult<TokenDTO>> SignIn([FromBody] SignInDTO signInDto)
    {
        var customer = await _sessionService.FindCustomer(signInDto)
            ?? throw new NotFoundError("Customer Not Found");

        var token = _tokenService.Generate(customer);

        return Ok(token);
    }
}
