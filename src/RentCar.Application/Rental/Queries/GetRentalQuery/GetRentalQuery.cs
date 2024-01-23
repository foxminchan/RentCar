// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Rental.Dto;

namespace RentCar.Application.Rental.Queries.GetRentalQuery;

public sealed record GetRentalQuery(Guid Id) : GetEntityQuery<RentalDto>(Id);
