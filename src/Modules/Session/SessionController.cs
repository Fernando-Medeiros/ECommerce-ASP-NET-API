using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Token;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Session;

[ApiController]
[Route("api/", Name = "Session")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(
        ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("signin")]
    public async Task<ActionResult<AccessTokenResource>> SignIn(
        [FromBody] SignInRequest request)
    {
        CustomerDTO customer = await _sessionService.FindCustomer(
            dto: SignInDTO.ExtractProperties(request));

        TokenDTO token = _sessionService.GenerateAccessToken(customer);

        AccessTokenResource resource = new(token);

        return Ok(resource);
    }
}
