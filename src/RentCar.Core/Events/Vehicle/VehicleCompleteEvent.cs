// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.SharedKernel;

namespace RentCar.Core.Events.Vehicle;

public sealed class VehicleCompleteEvent(Entities.Vehicle vehicle) : BaseEvent
{
    public Entities.Vehicle Vehicle { get; } = vehicle;
}
