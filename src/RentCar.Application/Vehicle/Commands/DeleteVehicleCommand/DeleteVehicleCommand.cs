// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;

using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.DeleteVehicleCommand;

public record DeleteVehicleCommand(Guid Id) : ICommand<Result>;
