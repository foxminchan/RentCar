// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Vehicle.Queries.GetVehiclesQuery;

public sealed class GetVehiclesQueryHandler(Repository<Core.Entities.Vehicle> repository)
    : GetEntitiesQueryHandler<GetVehiclesQuery, Core.Entities.Vehicle, VehicleDto, VehicleFilterPaginated>(repository);

public sealed class GetVehiclesQueryValidator : PagedValidator<GetVehiclesQuery>;
