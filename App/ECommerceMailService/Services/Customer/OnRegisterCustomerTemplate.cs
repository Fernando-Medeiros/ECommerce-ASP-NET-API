using ECommerceMailService.Contracts;
using ECommerceMailService.Templates;

namespace ECommerceMailService.Services.Customer;

public sealed record OnRegisterCustomerTemplate : ITemplate
{
    public OnRegisterCustomerTemplate(
        string To,
        AuthenticateEmailVM Model)
        : base(To, "Authenticate Email", "AuthenticateEmail", Model) { }
}
