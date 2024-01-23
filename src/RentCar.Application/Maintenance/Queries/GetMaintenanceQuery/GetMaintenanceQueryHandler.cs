// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;
using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Maintenance.Dto;
using RentCar.Core.Specifications.Maintenance;

namespace RentCar.Application.Maintenance.Queries.GetMaintenanceQuery;

public sealed class GetMaintenanceQueryHandler(IReadRepositoryBase<Core.Entities.Maintenance> repository)
    : GetEntityQueryHandler<GetMaintenanceQuery, Core.Entities.Maintenance, MaintenanceDto, MaintenanceById>(
        repository);
