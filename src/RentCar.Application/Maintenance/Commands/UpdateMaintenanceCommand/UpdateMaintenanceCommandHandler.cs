// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;
using RentCar.Application.Vehicle.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Maintenance.Commands.UpdateMaintenanceCommand;

public sealed class UpdateMaintenanceCommandHandler(Repository<Core.Entities.Maintenance> repository)
    : UpdateEntityCommandHandler<UpdateMaintenanceCommand, Core.Entities.Maintenance>(repository);

public sealed class UpdateMaintenanceCommandValidator : AbstractValidator<UpdateMaintenanceCommand>
{
    public UpdateMaintenanceCommandValidator(VehicleIdValidator vehicleIdValidator)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

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
