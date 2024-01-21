// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.Specification;
using MediatR;
using RentCar.Core.Specifications.Rental;

namespace RentCar.Application.Rental.Queries.GetRentalAmountQuery;

public sealed class GetRentalAmountQueryHandler(IReadRepositoryBase<Core.Entities.Rental> repository) 
    : IRequestHandler<GetRentalAmountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetRentalAmountQuery request, CancellationToken cancellationToken)
    {
        if (request.UserId is null)
            return await repository.CountAsync(cancellationToken);

        var spec = new RentalByUserId(request.UserId);
        return await repository.CountAsync(spec, cancellationToken);
    }
}
