// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;

namespace RentCar.Application.Maintenance.Commands.DeleteMaintenanceCommand;

public sealed record DeleteMaintenanceCommand(Guid Id) : DeleteEntityCommand(Id);
