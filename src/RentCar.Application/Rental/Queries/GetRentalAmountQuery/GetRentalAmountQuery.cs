// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using MediatR;

namespace RentCar.Application.Rental.Queries.GetRentalAmountQuery;

public record GetRentalAmountQuery(string? UserId = null) : IRequest<Result<int>>;
