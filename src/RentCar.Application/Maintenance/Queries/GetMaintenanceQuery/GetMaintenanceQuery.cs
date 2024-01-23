// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Maintenance.Dto;

namespace RentCar.Application.Maintenance.Queries.GetMaintenanceQuery;

public sealed record GetMaintenanceQuery(Guid Id) : GetEntityQuery<MaintenanceDto>(Id);
