// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.Rental.Dto;

namespace RentCar.Application.Rental.Queries.GetRentalsQuery;

public sealed record GetRentalsQuery(int Skip = 0, int Take = 20, string OrderBy = "Id")
    : IQuery<Result<IEnumerable<RentalDto>>>;
