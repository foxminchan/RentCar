// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.Vehicle.Queries.GetVehiclesQuery;

public sealed record GetVehiclesQuery(SpecificationBase Spec) : GetEntitiesQuery<VehicleDto>(Spec);
