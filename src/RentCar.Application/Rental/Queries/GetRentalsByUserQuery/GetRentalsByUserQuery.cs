// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.Rental.Dto;

namespace RentCar.Application.Rental.Queries.GetRentalsByUserQuery;

public record GetRentalsByUserQuery(int Skip, int Take, string OrderBy, string UserId) 
    : IQuery<Result<IEnumerable<RentalDto>>>;
