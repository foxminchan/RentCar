// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.Rental.Queries.GetRentalsQuery;

public sealed record GetRentalsQuery(SpecificationBase Spec) : GetEntitiesQuery<RentalDto>(Spec);
