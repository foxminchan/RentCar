// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using FluentValidation;
using Mapster;
using RentCar.Application.User.Validators;
using RentCar.Application.Vehicle.Validators;

namespace RentCar.Application.Rental.Commands.CreateRentalCommand;

public sealed class CreateRentalCommandHandler(IRepositoryBase<Core.Entities.Rental> repository)
    : ICommandHandler<CreateRentalCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Rental>();
        var result = await repository.AddAsync(entity, cancellationToken);
        result.AddRental(entity.VehicleId);
        return Result.Success(result.Id);
    }
}

public sealed class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator(
        VehicleIdValidator vehicleIdValidator, UserIdValidator userIdValidator)
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
            .WithMessage("Status is not valid");

        RuleFor(x => x.VehicleId)
            .SetValidator(vehicleIdValidator);

        RuleFor(x => x.UserId)
            .SetValidator(userIdValidator!);
    }
}
