// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using FluentValidation;

namespace RentCar.Application.Rental.Commands.DeleteRentalCommand;

public sealed class DeleteRentalCommandHandler(IRepositoryBase<Core.Entities.Rental> repository)
    : ICommandHandler<DeleteRentalCommand, Result>
{
    public async Task<Result> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request.Id, nameof(request));
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);
        await repository.DeleteAsync(entity, cancellationToken);
        entity.DeleteRental(entity.VehicleId, entity.VehicleId, entity.EndDate);
        return Result.Success();
    }
}

public sealed class DeleteRentalCommandValidator : AbstractValidator<DeleteRentalCommand>
{
    public DeleteRentalCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
