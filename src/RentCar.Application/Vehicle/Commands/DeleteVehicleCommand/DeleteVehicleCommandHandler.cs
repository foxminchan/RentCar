// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Specification;
using RentCar.Core.Events.Vehicle;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.DeleteVehicleCommand;

public sealed class DeleteVehicleCommandHandler(IRepositoryBase<Core.Entities.Vehicle> repository)
    : ICommandHandler<DeleteVehicleCommand, Result>
{
    public async Task<Result> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.AddDomainEvent(new VehicleDeletedEvent(entity.Id));

        await repository.DeleteAsync(entity, cancellationToken);

        return Result.Success();
    }
}
