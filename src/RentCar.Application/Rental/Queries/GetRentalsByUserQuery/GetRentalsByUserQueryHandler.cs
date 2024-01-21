// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Mapster;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications.Rental;

namespace RentCar.Application.Rental.Queries.GetRentalsByUserQuery;

public sealed class GetRentalsByUserQueryHandler(IReadRepositoryBase<Core.Entities.Rental> repository) 
    : IQueryHandler<GetRentalsByUserQuery, Result<IEnumerable<RentalDto>>>
{
    public async Task<Result<IEnumerable<RentalDto>>> Handle(GetRentalsByUserQuery request, CancellationToken cancellationToken)
    {
        var spec = new RentalByUserIdFilterPaginated(request.UserId, request.Skip, request.Take, request.OrderBy);
        var entities = await repository.ListAsync(spec, cancellationToken);
        Guard.Against.NotFound(request.UserId, entities);
        return Result.Success(entities.Adapt<IEnumerable<RentalDto>>());
    }
}
