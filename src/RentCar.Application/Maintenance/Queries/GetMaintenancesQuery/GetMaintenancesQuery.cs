// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Maintenance.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.Maintenance.Queries.GetMaintenancesQuery;

public sealed record GetMaintenancesQuery(SpecificationBase Spec) : GetEntitiesQuery<MaintenanceDto>(Spec);
