// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Maintenance.Dto;
using RentCar.Core.Specifications.Maintenance;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Maintenance.Queries.GetMaintenanceQuery;

public sealed class GetMaintenanceQueryHandler(Repository<Core.Entities.Maintenance> repository)
    : GetEntityQueryHandler<GetMaintenanceQuery, Core.Entities.Maintenance, MaintenanceDto, MaintenanceById>(
        repository);
