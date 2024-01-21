// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.SharedKernel;

namespace RentCar.Core.Events.Vehicle;

public sealed class VehicleDeletedEvent(Guid id) : BaseEvent
{
    public Guid Id { get; } = id;
}
