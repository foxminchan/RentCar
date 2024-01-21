// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;

using RentCar.Core.Interfaces;

namespace RentCar.Core.Events.Rental;

public sealed class RentalDeletedEvent(Guid vehicleId, Guid rentalId, DateTime? endDate)
    : DomainEventBase, ITransactionRequest
{
    public Guid VehicleId { get; } = vehicleId;
    public Guid RentalId { get; } = rentalId;
    public DateTime? EndDate { get; } = endDate;
}
