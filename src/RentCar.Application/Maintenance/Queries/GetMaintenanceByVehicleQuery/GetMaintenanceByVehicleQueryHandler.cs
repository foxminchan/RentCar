// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesByFieldQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Maintenance.Dto;
using RentCar.Core.Specifications.Maintenance;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Maintenance.Queries.GetMaintenanceByVehicleQuery;

public sealed class GetMaintenanceByVehicleQueryHandler(Repository<Core.Entities.Maintenance> repository)
    : GetEntitiesByFieldQueryHandler<GetMaintenanceByVehicleQuery, Core.Entities.Maintenance, MaintenanceDto,
        MaintenanceByVehicleId>(repository);

public sealed class GetMaintenanceByVehicleValidator : PagedValidator<GetMaintenanceByVehicleQuery>;
