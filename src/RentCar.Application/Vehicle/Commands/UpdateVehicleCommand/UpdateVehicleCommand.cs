// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using MediatR;
using RentCar.Core.Enums;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.UpdateVehicleCommand;

public record UpdateVehicleCommand(
    Ulid Id,
    string? Name,
    string? Brand,
    string? Color,
    string? Plate,
    VehicleType? Type,
    CarStatus? Status,
    string? Image) : ICommand<Result<Unit>>;
