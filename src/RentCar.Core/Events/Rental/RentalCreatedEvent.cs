// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;

namespace RentCar.Core.Events.Rental;

public sealed class RentalCreatedEvent(Guid vehicleId) : DomainEventBase
{
    public Guid VehicleId { get; set; } = vehicleId;
}
