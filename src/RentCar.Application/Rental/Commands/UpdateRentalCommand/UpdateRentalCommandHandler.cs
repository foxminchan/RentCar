﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using FluentValidation;
using Mapster;
using RentCar.Application.Payment.Validators;
using RentCar.Application.User.Validators;
using RentCar.Application.Vehicle.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Rental.Commands.UpdateRentalCommand;

public sealed class UpdateRentalCommandHandler(Repository<Core.Entities.Rental> repository)
    : ICommandHandler<UpdateRentalCommand, Result>
{
    public async Task<Result> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Rental>();
        var existItem = await repository.GetByIdAsync(entity.Id, cancellationToken);
        Guard.Against.NotFound(entity.Id, existItem);
        await repository.UpdateAsync(entity, cancellationToken);
        existItem.UpdateRental(entity.Id, entity.VehicleId, entity.Status);
        return Result.Success();
    }
}

public sealed class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
{
    public UpdateRentalCommandValidator(
        VehicleIdValidator vehicleIdValidator, UserIdValidator userIdValidator, PaymentIdValidator paymentIdValidator)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be greater than start date");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0)
            .WithMessage("Total price must be greater than 0");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status is not valid");

        RuleFor(x => x.VehicleId)
            .SetValidator(vehicleIdValidator);

        RuleFor(x => x.UserId)
            .SetValidator(userIdValidator);

        RuleFor(x => x.PaymentId)
            .SetValidator(paymentIdValidator);
    }
}
