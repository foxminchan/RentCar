using FluentValidation;
using RentCar.Core.ValueObjects;

namespace RentCar.Application.User.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.City)
            .MaximumLength(50)
            .WithMessage("City must not exceed 50 characters")
            .NotEmpty()
            .WithMessage("City is required");

        RuleFor(a => a.Street)
            .MaximumLength(50)
            .WithMessage("Street must not exceed 50 characters")
            .NotEmpty()
            .WithMessage("Street is required");

        RuleFor(a => a.Ward)
            .MaximumLength(50)
            .WithMessage("Ward must not exceed 50 characters")
            .NotEmpty()
            .WithMessage("Ward is required");

        RuleFor(a => a.Province)
            .MaximumLength(50)
            .WithMessage("Province must not exceed 50 characters")
            .NotEmpty()
            .WithMessage("Province is required");
    }
}
