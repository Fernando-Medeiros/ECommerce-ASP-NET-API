using FluentValidation;

namespace ECommerceApplication.Requests;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("The Name is Required")
            .Length(3, 20).WithMessage("The Name must be between 3 and 20 characters");

        RuleFor(x => x.FirstName)
            .NotNull().NotEmpty().WithMessage("The FirstName is Required")
            .Length(3, 20).WithMessage("The FirstName must be between 3 and 20 characters");

        RuleFor(x => x.LastName)
            .NotNull().NotEmpty().WithMessage("The LastName is Required")
            .Length(3, 20).WithMessage("The LastName must be between 3 and 20 characters");

        RuleFor(x => x.Email)
            .NotNull().NotEmpty().WithMessage("The Email is Required")
            .Length(6, 155).WithMessage("The Email must be between 6 and 155 characters")
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull().NotEmpty().WithMessage("The Password is Required")
            .Length(8, 16).WithMessage("The Password must be between 6 and 16 characters");
    }
}