using Ardalis.Result;
using Ardalis.Specification;
using FluentValidation;

using Mapster;
using RentCar.Core.Events.Vehicle;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.CreateVehicleCommand;

public sealed class CreateVehicleCommandHandler(IRepositoryBase<Core.Entities.Vehicle> repository)
    : ICommandHandler<CreateVehicleCommand, Result<Core.Entities.Vehicle>>
{
    public async Task<Result<Core.Entities.Vehicle>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Vehicle>();
        entity.AddDomainEvent(new VehicleCreatedEvent(entity));
        return await repository.AddAsync(entity, cancellationToken);
    }
}

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
            .MaximumLength(20);

        RuleFor(x => x.Vehicle.Plate)
            .NotEmpty()
            .MaximumLength(10);

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
