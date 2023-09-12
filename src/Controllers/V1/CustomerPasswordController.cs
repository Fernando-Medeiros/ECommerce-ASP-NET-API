using ECommerce.Identities;
using ECommerce.ModulesHelpers.Token;
using ECommerce.Setup.ApiProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.CustomerPassword;

[ApiController, Authorize, Route("api/v1/passwords")]
[BadRequest, Unauthorized, Forbidden, NotFound]
public class CustomerPasswordController : ControllerBase
{
    private readonly ICustomerPasswordService _service;

    public CustomerPasswordController(
        ICustomerPasswordService service) => _service = service;

    [HttpPost("recover"), AllowAnonymous]
    [Success(typeof(string))]
    public async Task<ActionResult> Recover(
        [FromBody] PasswordRecoverRequest request)
    {
        await _service.RecoverPassword(
            dto: new PasswordRecoverDTO(request.Email!));

        return Ok("The link to reset your password has been sent to your email.");
    }

    [HttpPatch("reset")]
    [NoContent]
    public async Task<ActionResult> Reset(
        [FromBody] PasswordUpdateRequest request)
    {
        CustomerIdentity customer = new(User, new() { ETokenScope.RecoverPassword });

        await _service.UpdatePassword(
            dto: PasswordUpdateDTO.ExtractProperties(req: request, customer.Id));

        return NoContent();
    }

    [HttpPatch("update")]
    [NoContent]
    public async Task<ActionResult> Update(
        [FromBody] PasswordUpdateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _service.UpdatePassword(
            dto: PasswordUpdateDTO.ExtractProperties(req: request, customer.Id));

        return NoContent();
    }
}
