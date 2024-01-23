// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Vehicle.Dto;
using RentCar.Core.Specifications;
using RentCar.Infrastructure.Abstraction.Queries.GetEntitiesQuery;

namespace RentCar.Application.Vehicle.Queries.GetVehiclesQuery;

public sealed record GetVehiclesQuery(SpecificationBase Spec) : GetEntitiesQuery<VehicleDto>(Spec);
