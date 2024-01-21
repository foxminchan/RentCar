// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;
using RentCar.Core.Enums;
using RentCar.Core.Interfaces;

namespace RentCar.Core.Events.Rental;

public class RentalUpdatedEvent(Guid vehicleId, Guid rentalId, RentStatus? status)
    : DomainEventBase, ITransactionRequest
{
    public RentStatus? Status { get; set; } = status;
    public Guid VehicleId { get; set; } = vehicleId;
    public Guid RentalId { get; set; } = rentalId;
}
