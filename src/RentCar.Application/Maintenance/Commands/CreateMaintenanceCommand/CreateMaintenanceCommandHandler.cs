// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using FluentValidation;
using Mapster;
using RentCar.Application.Vehicle.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Maintenance.Commands.CreateMaintenanceCommand;

public sealed class CreateMaintenanceCommandHandler(Repository<Core.Entities.Maintenance> repository)
    : ICommandHandler<CreateMaintenanceCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Maintenance>();
        var result = await repository.AddAsync(entity, cancellationToken);
        result.AddMaintenance(result.VehicleId);
        return Result.Success(result.Id);
    }
}

public sealed class CreateMaintenanceCommandValidator : AbstractValidator<CreateMaintenanceCommand>
{
    public CreateMaintenanceCommandValidator(VehicleIdValidator vehicleIdValidator)
    {
        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date is required");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .MaximumLength(255)
            .WithMessage("Description must not exceed 255 characters");

        RuleFor(x => x.Cost)
            .GreaterThan(0)
            .WithMessage("Cost must be greater than 0");

        RuleFor(x => x.VehicleId)
            .SetValidator(vehicleIdValidator);
    }
}
