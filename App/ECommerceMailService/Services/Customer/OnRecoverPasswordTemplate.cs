using ECommerceMailService.Contracts;
using ECommerceMailService.Templates;

namespace ECommerceMailService.Services.Customer;

public sealed record OnRecoverPasswordTemplate : ITemplate
{
    public OnRecoverPasswordTemplate(
        string To,
        RecoverPasswordVM Model)
        : base(To, "Recover Password", "RecoverPassword", Model) { }
}
