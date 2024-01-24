// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using MediatR;
using RentCar.Core.Enums;
using RentCar.Core.Events.Rental;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Rental.Handlers;

public sealed class RentalDeletedEventHandler(Repository<Core.Entities.Vehicle> repository)
    : INotificationHandler<RentalDeletedEvent>
{
    public async Task Handle(RentalDeletedEvent notification, CancellationToken cancellationToken)
    {
        Guard.Against.Null(notification, nameof(notification));
        var spec = new VehicleById(notification.VehicleId);
        var vehicle = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        Guard.Against.NotFound(notification.VehicleId, vehicle);

        if (vehicle is { Rentals: { }, Status: CarStatus.Rented }
            && vehicle.Rentals.Select(x => x.Id).Contains(notification.RentalId)
            && notification.EndDate <= DateTime.UtcNow
           )
        {
            vehicle.Status = CarStatus.Available;
            await repository.UpdateAsync(vehicle, cancellationToken);
        }
    }
}
