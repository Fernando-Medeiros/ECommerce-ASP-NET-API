using FluentValidation;

namespace ECommerceApplication.Requests;

public sealed class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .Length(3, 20).WithMessage("The Name must be between 3 and 20 characters");

        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.Stop)
            .Length(3, 20).WithMessage("The FirstName must be between 3 and 20 characters");

        RuleFor(x => x.LastName)
            .Cascade(CascadeMode.Stop)
            .Length(3, 20).WithMessage("The LastName must be between 3 and 20 characters");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .Length(6, 155).WithMessage("The Email must be between 6 and 155 characters")
            .EmailAddress();
    }
}