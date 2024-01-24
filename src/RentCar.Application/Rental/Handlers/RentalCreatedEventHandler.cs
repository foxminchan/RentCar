// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using MediatR;
using RentCar.Core.Enums;
using RentCar.Core.Events.Rental;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Rental.Handlers;

public sealed class RentalCreatedEventHandler(Repository<Core.Entities.Vehicle> repository) 
    : INotificationHandler<RentalCreatedEvent>
{
    public async Task Handle(RentalCreatedEvent notification, CancellationToken cancellationToken)
    {
        Guard.Against.Null(notification, nameof(notification));
        var spec = new VehicleById(notification.VehicleId);
        var vehicle = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        Guard.Against.NotFound(notification.VehicleId, vehicle);
        vehicle.Status = CarStatus.Rented;
        await repository.UpdateAsync(vehicle, cancellationToken);
    }
}
