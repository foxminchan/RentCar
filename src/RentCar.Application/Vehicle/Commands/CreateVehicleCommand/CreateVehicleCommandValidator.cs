using FluentValidation;

namespace RentCar.Application.Vehicle.Commands.CreateVehicleCommand;

public sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.Vehicle.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Vehicle.Brand)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Vehicle.Color)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Vehicle.Plate)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Vehicle.Type)
            .NotEmpty()
            .IsInEnum();

        RuleFor(x => x.Vehicle.Status)
            .NotEmpty()
            .IsInEnum();

        RuleFor(x => x.Vehicle.Image)
            .NotEmpty()
            .MaximumLength(255);
    }
}
