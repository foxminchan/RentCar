// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications.Rental;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Rental.Queries.GetRentalsQuery;

public sealed class GetRentalsQueryHandler(Repository<Core.Entities.Rental> repository) 
    : GetEntitiesQueryHandler<GetRentalsQuery, Core.Entities.Rental, RentalDto, RentalFilterPaginated>(repository);

public sealed class GetRentalsQueryValidator : PagedValidator<GetRentalsQuery>;
