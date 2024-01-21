// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using FluentValidation;
using Mapster;
using MediatR;
using RentCar.Core.Events.Rental;

namespace RentCar.Application.Rental.Commands.CreateRentalCommand;

public class CreateRentalCommandHandler(IRepositoryBase<Core.Entities.Rental> repository, IPublisher mediator)
    : ICommandHandler<CreateRentalCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Rental>();
        var result = await repository.AddAsync(entity, cancellationToken);
        await mediator.Publish(new RentalCreatedEvent(result), cancellationToken);
        return Result.Success(result.Id);
    }
}

public sealed class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
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
