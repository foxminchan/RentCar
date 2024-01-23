// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;

namespace RentCar.Application.Maintenance.Commands.DeleteMaintenanceCommand;

public sealed class DeleteMaintenanceCommandHandler(IRepositoryBase<Core.Entities.Maintenance> repository)
    : DeleteEntityCommandHandler<DeleteMaintenanceCommand, Core.Entities.Maintenance>(repository);
