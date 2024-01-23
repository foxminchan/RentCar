// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;
using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Maintenance.Dto;
using RentCar.Core.Specifications.Maintenance;

namespace RentCar.Application.Maintenance.Queries.GetMaintenancesQuery;

public class GetMaintenancesQueryHandler(IReadRepositoryBase<Core.Entities.Maintenance> repository)
    : GetEntitiesQueryHandler<GetMaintenancesQuery, Core.Entities.Maintenance, MaintenanceDto,
        MaintenanceFilterPaginated>(repository);

public class GetMaintenancesValidator : PagedValidator<GetMaintenancesQuery>;
