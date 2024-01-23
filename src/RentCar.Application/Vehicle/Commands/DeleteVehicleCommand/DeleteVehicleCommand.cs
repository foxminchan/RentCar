// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;

namespace RentCar.Application.Vehicle.Commands.DeleteVehicleCommand;

public sealed record DeleteVehicleCommand(Guid Id) : DeleteEntityCommand(Id);
