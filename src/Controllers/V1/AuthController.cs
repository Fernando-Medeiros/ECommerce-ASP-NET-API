using ECommerce.Identities;
using ECommerce.ModulesHelpers.Token;
using ECommerce.Startup.SwaggerProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Auth;

[ApiController, Authorize, Route("api/v1/auth")]
[BadRequest, Unauthorized, Forbidden, NotFound, Created(typeof(TokenResource))]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(
        IAuthService service) => _service = service;

    [HttpPost("signin"), AllowAnonymous]
    public async Task<ActionResult> SignIn(
        [FromBody] SignInRequest request)
    {
        TokenDTO token = await _service.SignIn(
            dto: SignInDTO.ExtractProperties(request));

        TokenResource resource = new(token);

        return Created("", resource);
    }


    [HttpPost("authenticate")]
    public async Task<ActionResult> AuthenticateEmail(
        [FromBody] SignInRequest request)
    {
        CustomerIdentity customer = new(
            User, new() { ETokenScope.AuthenticateEmail });

        TokenDTO token = await _service.Authenticate(
            dto: SignInDTO.ExtractProperties(request, customer.Id));

        TokenResource resource = new(token);

        return Created("", resource);
    }
}
