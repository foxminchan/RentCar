// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Specification;
using FluentValidation;
using Mapster;
using MediatR;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.UpdateVehicleCommand;

public sealed class UpdateVehicleCommandHandler(IRepositoryBase<Core.Entities.Vehicle> repository)
    : ICommandHandler<UpdateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Vehicle>();

        var existItem = await repository.GetByIdAsync(entity.Id, cancellationToken);

        Guard.Against.NotFound(entity.Id, existItem);

        await repository.UpdateAsync(entity, cancellationToken);

        return Result.Success(Unit.Value);
    }
}

public sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull();

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
