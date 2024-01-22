// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;

namespace RentCar.Application.Rental.Queries.GetRentalAmountQuery;

public sealed record GetRentalAmountQuery(string? UserId = null) : IQuery<Result<int>>;
