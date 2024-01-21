// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using MediatR;
using RentCar.Application.Rental.Dto;

namespace RentCar.Application.Rental.Queries.GetRentalQuery;

public record GetRentalQuery(Guid Id) : IRequest<Result<RentalDto>>;
