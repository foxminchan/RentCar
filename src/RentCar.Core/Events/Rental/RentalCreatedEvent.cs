// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;

namespace RentCar.Core.Events.Rental;

public class RentalCreatedEvent(Entities.Rental rental) : DomainEventBase
{
    public Entities.Rental Rental { get; } = rental;
}
