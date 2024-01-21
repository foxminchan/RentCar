// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.Vehicle.Dto;

namespace RentCar.Application.Vehicle.Queries.GetVehiclesQuery;

public record GetVehiclesQuery(int Skip = 0, int Take = 20, string OrderBy = "Id") 
    : IQuery<Result<IEnumerable<VehicleDto>>>;
