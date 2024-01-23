// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesByFieldQuery;
using RentCar.Application.Maintenance.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.Maintenance.Queries.GetMaintenanceByVehicleQuery;

public sealed record GetMaintenanceByVehicleQuery(Guid VehicleId, SpecificationBase Spec)
    : GetEntitiesByFieldQuery<MaintenanceDto>(VehicleId, Spec);
