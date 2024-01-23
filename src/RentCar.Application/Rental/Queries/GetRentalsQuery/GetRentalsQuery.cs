// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications;
using RentCar.Infrastructure.Abstraction.Queries.GetEntitiesQuery;

namespace RentCar.Application.Rental.Queries.GetRentalsQuery;

public sealed record GetRentalsQuery(SpecificationBase Spec) : GetEntitiesQuery<RentalDto>(Spec);
