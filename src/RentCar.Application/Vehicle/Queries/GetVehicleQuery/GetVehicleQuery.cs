// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Queries.GetVehicleQuery;

public record GetVehicleQuery(Guid Id) : IQuery<Result<VehicleDto>>;
