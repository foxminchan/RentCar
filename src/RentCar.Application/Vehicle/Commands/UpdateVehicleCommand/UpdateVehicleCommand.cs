// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Http;
using RentCar.Core.Enums;
using RentCar.Infrastructure.Abstraction.Commands.UpdateEntityCommand;

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
