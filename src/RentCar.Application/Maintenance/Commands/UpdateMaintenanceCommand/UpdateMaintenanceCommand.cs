// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;

namespace RentCar.Application.Maintenance.Commands.UpdateMaintenanceCommand;

public sealed record UpdateMaintenanceCommand(
    Guid Id,
    DateTime? Date,
    string? Description,
    decimal? Cost,
    Guid? VehicleId) : UpdateEntityCommand;
