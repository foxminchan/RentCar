// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Vehicle.Queries.GetVehicleQuery;

public sealed class GetVehicleQueryHandler(Repository<Core.Entities.Vehicle> repository)
    : GetEntityQueryHandler<GetVehicleQuery, Core.Entities.Vehicle, VehicleDto, VehicleById>(repository);
