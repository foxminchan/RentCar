// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Mapster;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications.Rental;

namespace RentCar.Application.Rental.Queries.GetRentalsQuery;

public sealed class GetRentalsQueryHandler(IReadRepositoryBase<Core.Entities.Rental> repository) 
    : IQueryHandler<GetRentalsQuery, Result<IEnumerable<RentalDto>>>
{
    public async Task<Result<IEnumerable<RentalDto>>> Handle(GetRentalsQuery request, CancellationToken cancellationToken)
    {
        var spec = new RentalFilterPaginated(request.Skip, request.Take, request.OrderBy);
        var entities = await repository.ListAsync(spec, cancellationToken);
        return Result.Success(entities.Adapt<IEnumerable<RentalDto>>());
    }
}
