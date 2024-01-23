// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Vehicle.Dto;

namespace RentCar.Application.Vehicle.Queries.GetVehicleQuery;

public sealed record GetVehicleQuery(Guid Id) : GetEntityQuery<VehicleDto>(Id);
