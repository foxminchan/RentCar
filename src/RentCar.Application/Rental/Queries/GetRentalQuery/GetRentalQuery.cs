// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.Rental.Dto;

namespace RentCar.Application.Rental.Queries.GetRentalQuery;

public sealed record GetRentalQuery(Guid Id) : IQuery<Result<RentalDto>>;
