// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using MediatR;
using Microsoft.Extensions.Logging;
using RentCar.Core.Events.Vehicle;

namespace RentCar.Application.Vehicle.EventHandlers;

public sealed class VehicleCreatedEventHandler(ILogger<VehicleCreatedEventHandler> logger) 
    : INotificationHandler<VehicleCreatedEvent>
{
    public Task Handle(VehicleCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Vehicle domain event created: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
