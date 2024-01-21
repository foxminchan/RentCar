// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Specification;
using MediatR;
using RentCar.Core.Enums;
using RentCar.Core.Events.Rental;
using RentCar.Core.Specifications.Vehicle;

namespace RentCar.Application.Rental.Handlers;

public sealed class RentalCreatedEventHandler(IRepositoryBase<Core.Entities.Vehicle> repository) 
    : INotificationHandler<RentalCreatedEvent>
{
    public async Task Handle(RentalCreatedEvent notification, CancellationToken cancellationToken)
    {
        var spec = new VehicleById(notification.Rental.VehicleId);
        var vehicle = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        Guard.Against.NotFound(notification.Rental.VehicleId, vehicle);
        vehicle.Status = CarStatus.Rented;
        await repository.UpdateAsync(vehicle, cancellationToken);
    }
}
