// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using MediatR;
using RentCar.Core.Enums;
using RentCar.Core.Events.Maintenance;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Maintenance.Handlers;

public class MaintenanceCreatedEventHandler(Repository<Core.Entities.Vehicle> repository)
    : INotificationHandler<MaintenanceCreatedEvent>
{
    public async Task Handle(MaintenanceCreatedEvent notification, CancellationToken cancellationToken)
    {
        Guard.Against.Null(notification, nameof(notification));
        var spec = new VehicleById(notification.VehicleId);
        var vehicle = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        Guard.Against.NotFound(notification.VehicleId, vehicle);
        vehicle.Status = CarStatus.Repairing;
        await repository.UpdateAsync(vehicle, cancellationToken);
    }
}
