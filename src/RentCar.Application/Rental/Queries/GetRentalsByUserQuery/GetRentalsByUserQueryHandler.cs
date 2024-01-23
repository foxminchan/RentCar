// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

using RentCar.Application.Abstraction.Queries.GetEntitiesByFieldQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications.Rental;

namespace RentCar.Application.Rental.Queries.GetRentalsByUserQuery;

public sealed class GetRentalsByUserQueryHandler(IReadRepositoryBase<Core.Entities.Rental> repository)
    : GetEntitiesByFieldQueryHandler<GetRentalsByUserQuery, Core.Entities.Rental, RentalDto, RentalByUserIdFilterPaginated>(repository);

public sealed class GetRentalsByUserQueryValidator : PagedValidator<GetRentalsByUserQuery>;
