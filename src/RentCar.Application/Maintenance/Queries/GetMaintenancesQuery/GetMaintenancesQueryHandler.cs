// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Maintenance.Dto;
using RentCar.Core.Specifications.Maintenance;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Maintenance.Queries.GetMaintenancesQuery;

public class GetMaintenancesQueryHandler(Repository<Core.Entities.Maintenance> repository)
    : GetEntitiesQueryHandler<GetMaintenancesQuery, Core.Entities.Maintenance, MaintenanceDto,
        MaintenanceFilterPaginated>(repository);

public class GetMaintenancesValidator : PagedValidator<GetMaintenancesQuery>;
