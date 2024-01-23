// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications;
using RentCar.Infrastructure.Abstraction.Queries.GetEntitiesByFieldQuery;

namespace RentCar.Application.Rental.Queries.GetRentalsByUserQuery;

public sealed record GetRentalsByUserQuery(Guid UserId, SpecificationBase Spec)
    : GetEntitiesByFieldQuery<RentalDto>(UserId, Spec);
