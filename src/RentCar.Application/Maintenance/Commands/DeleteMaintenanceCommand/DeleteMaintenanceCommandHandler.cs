// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Maintenance.Commands.DeleteMaintenanceCommand;

public sealed class DeleteMaintenanceCommandHandler(Repository<Core.Entities.Maintenance> repository)
    : DeleteEntityCommandHandler<DeleteMaintenanceCommand, Core.Entities.Maintenance>(repository);
