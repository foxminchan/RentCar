// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Http;
using RentCar.Core.Enums;
using RentCar.Infrastructure.Abstraction.Commands.CreateEntityCommand;

namespace RentCar.Application.Vehicle.Commands.CreateVehicleCommand;

public sealed record CreateVehicleCommand(
    string? Name,
    string? Brand,
    string? Color,
    string? Plate,
    VehicleType? Type,
    CarStatus? Status,
    IFormFile? ImageFile) : CreateEntityCommand;
