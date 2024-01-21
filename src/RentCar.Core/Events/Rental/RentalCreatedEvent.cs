﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;
using RentCar.Core.Interfaces;

namespace RentCar.Core.Events.Rental;

public sealed class RentalCreatedEvent(Guid vehicleId) : DomainEventBase, ITransactionRequest
{
    public Guid VehicleId { get; set; } = vehicleId;
}
