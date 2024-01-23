// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Abstraction.Queries.GetEntityQuery;

namespace RentCar.Application.Vehicle.Queries.GetVehicleQuery;

public sealed class GetVehicleQueryHandler(IReadRepositoryBase<Core.Entities.Vehicle> repository)
    : GetEntityQueryHandler<GetVehicleQuery, Core.Entities.Vehicle, VehicleDto, VehicleById>(repository);
