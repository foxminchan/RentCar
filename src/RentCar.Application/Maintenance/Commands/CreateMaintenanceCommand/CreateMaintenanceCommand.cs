// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.CreateEntityCommand;

namespace RentCar.Application.Maintenance.Commands.CreateMaintenanceCommand;

public sealed record CreateMaintenanceCommand(
    DateTime? Date,
    string? Description,
    decimal? Cost,
    Guid? VehicleId) : CreateEntityCommand;
