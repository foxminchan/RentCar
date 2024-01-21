﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using FluentValidation;
using Mapster;
using MediatR;

using RentCar.Core.Events.Rental;

namespace RentCar.Application.Rental.Commands.UpdateRentalCommand;

public sealed class UpdateRentalCommandHandler(IRepositoryBase<Core.Entities.Rental> repository, IPublisher mediator) 
    : ICommandHandler<UpdateRentalCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Rental>();
        var existItem = await repository.GetByIdAsync(entity.Id, cancellationToken);
        Guard.Against.NotFound(entity.Id, existItem);
        await repository.UpdateAsync(entity, cancellationToken);
        await mediator.Publish(new RentalUpdatedEvent(entity.Id, entity.VehicleId, entity.Status), cancellationToken);
        return Result.Success(Unit.Value);
    }
}

public sealed class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
{
    public UpdateRentalCommandValidator()
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
            .WithMessage("Status must be in enum");

        RuleFor(x => x.VehicleId)
            .NotEmpty()
            .WithMessage("Vehicle id is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User id is required");
    }
}