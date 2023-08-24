using ECommerce.Identities;
using ECommerce.ModulesHelpers.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.CustomerPassword;

[ApiController]
[Route("api/v1/passwords")]
public class CustomerPasswordController : ControllerBase
{
    private readonly ICustomerPasswordService _service;

    public CustomerPasswordController(
        ICustomerPasswordService service)
    {
        _service = service;
    }

    [HttpPost("recover")]
    public async Task<ActionResult> Recover(
        [FromBody] PasswordRecoverRequest request)
    {
        await _service.RecoverPassword(
            dto: new PasswordRecoverDTO(request.Email!));

        return Ok(new
        {
            message = "The link to reset your password has been sent to your email."
        });
    }

    [Authorize]
    [HttpPatch("reset")]
    public async Task<ActionResult> Reset(
        [FromBody] PasswordUpdateRequest request)
    {
        CustomerIdentity customer = new(User, new() { ETokenScope.RecoverPassword });

        await _service.UpdatePassword(
            dto: PasswordUpdateDTO.ExtractProperties(req: request, customer.Id));

        return NoContent();
    }

    [Authorize]
    [HttpPatch("update")]
    public async Task<ActionResult> Update(
        [FromBody] PasswordUpdateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _service.UpdatePassword(
            dto: PasswordUpdateDTO.ExtractProperties(req: request, customer.Id));

        return NoContent();
    }
}
