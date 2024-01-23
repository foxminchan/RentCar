// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Vehicle.Dto;
using RentCar.Infrastructure.Abstraction.Queries.GetEntityQuery;

namespace RentCar.Application.Vehicle.Queries.GetVehicleQuery;

public sealed record GetVehicleQuery(Guid Id) : GetEntityQuery<VehicleDto>(Id);
