// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Rental.Dto;
using RentCar.Infrastructure.Abstraction.Queries.GetEntityQuery;

namespace RentCar.Application.Rental.Queries.GetRentalQuery;

public sealed record GetRentalQuery(Guid Id) : GetEntityQuery<RentalDto>(Id);
