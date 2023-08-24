using ECommerce.Identities;
using ECommerce.ModulesHelpers.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Auth;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signin")]
    public async Task<ActionResult<TokenResource>> SignIn(
        [FromBody] SignInRequest request)
    {
        TokenDTO token = await _authService.SignIn(
            dto: SignInDTO.ExtractProperties(request));

        TokenResource resource = new(token);

        return Ok(resource);
    }

    [Authorize]
    [HttpPost("authenticate")]
    public async Task<ActionResult<TokenResource>> AuthenticateEmail(
        [FromBody] SignInRequest request)
    {
        CustomerIdentity customer = new(
            User, new() { ETokenScope.AuthenticateEmail });

        TokenDTO token = await _authService.Authenticate(
            dto: SignInDTO.ExtractProperties(request, customer.Id));

        TokenResource resource = new(token);

        return Ok(resource);
    }
}
