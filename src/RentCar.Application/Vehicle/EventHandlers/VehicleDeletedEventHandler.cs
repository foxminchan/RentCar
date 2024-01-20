// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using MediatR;
using Microsoft.Extensions.Logging;
using RentCar.Core.Events.Vehicle;

namespace RentCar.Application.Vehicle.EventHandlers;

public sealed class VehicleDeletedEventHandler(ILogger<VehicleDeletedEventHandler> logger)
    : INotificationHandler<VehicleDeletedEvent>
{
    public Task Handle(VehicleDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Vehicle domain event deleted: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
