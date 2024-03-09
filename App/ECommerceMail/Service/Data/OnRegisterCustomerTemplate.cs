using ECommerceMail.Contract;
using ECommerceMail.Template;

namespace ECommerceMail.Service.Data;

public sealed record OnRegisterCustomerTemplate : BaseTemplate
{
    public OnRegisterCustomerTemplate(
        string To,
        AuthenticateEmailVM Model)
        : base(To, "Authenticate Email", "AuthenticateEmail", Model) { }
}
