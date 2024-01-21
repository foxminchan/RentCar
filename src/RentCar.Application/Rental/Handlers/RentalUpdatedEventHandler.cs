// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Specification;
using MediatR;
using RentCar.Core.Enums;
using RentCar.Core.Events.Rental;
using RentCar.Core.Specifications.Rental;
using RentCar.Core.Specifications.Vehicle;

namespace RentCar.Application.Rental.Handlers;

public sealed class RentalUpdatedEventHandler(
    IRepositoryBase<Core.Entities.Vehicle> vehicleRepository,
    IRepositoryBase<Core.Entities.Rental> rentalRepository) : INotificationHandler<RentalUpdatedEvent>
{
    public async Task Handle(RentalUpdatedEvent notification, CancellationToken cancellationToken)
    {
        Guard.Against.Null(notification, nameof(notification));

        var vehicleSpec = new VehicleById(notification.VehicleId);
        var vehicle = await vehicleRepository.FirstOrDefaultAsync(vehicleSpec, cancellationToken);
        Guard.Against.NotFound(notification.VehicleId, vehicle);

        var rentalSpec = new RentalById(notification.RentalId);
        var rental = await rentalRepository.FirstOrDefaultAsync(rentalSpec, cancellationToken);
        Guard.Against.NotFound(notification.RentalId, rental);

        if (rental.EndDate <= DateTime.UtcNow)
        {
            vehicle.Status = CarStatus.Available;
            rental.Status = RentStatus.Returned;
            await vehicleRepository.UpdateAsync(vehicle, cancellationToken);
            await rentalRepository.UpdateAsync(rental, cancellationToken);
        }

        if (notification.Status is RentStatus.Cancelled or RentStatus.Returned)
        {
            vehicle.Status = CarStatus.Available;
            await vehicleRepository.UpdateAsync(vehicle, cancellationToken);
        }
    }
}
