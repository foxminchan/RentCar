// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.Specification;
using FluentValidation;
using Mapster;
using RentCar.Core.Events.Vehicle;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.CreateVehicleCommand;

public sealed class CreateVehicleCommandHandler(IRepositoryBase<Core.Entities.Vehicle> repository)
    : ICommandHandler<CreateVehicleCommand, Result<Ulid>>
{
    public async Task<Result<Ulid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Vehicle>();
        entity.AddDomainEvent(new VehicleCreatedEvent(entity));
        var result = await repository.AddAsync(entity, cancellationToken);
        return Result.Success(result.Id);
    }
}

public sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Brand)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Color)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Plate)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Type)
            .NotEmpty()
            .IsInEnum();

        RuleFor(x => x.Status)
            .NotEmpty()
            .IsInEnum();

        RuleFor(x => x.Image)
            .NotEmpty()
            .MaximumLength(255);
    }
}
