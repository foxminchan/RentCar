// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications.Rental;

namespace RentCar.Application.Rental.Queries.GetRentalQuery;

public sealed class GetRentalQueryHandler(IReadRepositoryBase<Core.Entities.Rental> repository)
    : GetEntityQueryHandler<GetRentalQuery, Core.Entities.Rental, RentalDto, RentalById>(repository);
