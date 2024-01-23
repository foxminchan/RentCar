// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Http;

using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;
using RentCar.Core.Enums;

namespace RentCar.Application.Vehicle.Commands.UpdateVehicleCommand;

public sealed record UpdateVehicleCommand(
    Guid Id,
    string? Name,
    string? Brand,
    string? Color,
    string? Plate,
    VehicleType? Type,
    CarStatus? Status,
    IFormFile? ImageFile,
    string? Image) : UpdateEntityCommand;
