// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesByFieldQuery;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.Rental.Queries.GetRentalsByUserQuery;

public sealed record GetRentalsByUserQuery(Guid Id, SpecificationBase Spec)
    : GetEntitiesByFieldQuery<RentalDto>(Id, Spec);
