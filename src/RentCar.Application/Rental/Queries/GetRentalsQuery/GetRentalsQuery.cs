// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.Rental.Dto;

namespace RentCar.Application.Rental.Queries.GetRentalsQuery;

public record GetRentalsQuery(int Skip, int Take, string OrderBy) : IQuery<Result<IEnumerable<RentalDto>>>;
