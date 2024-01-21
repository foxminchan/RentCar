// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Specification;
using Mapster;
using MediatR;
using RentCar.Application.Rental.Dto;
using RentCar.Core.Specifications.Rental;

namespace RentCar.Application.Rental.Queries.GetRentalQuery;

public sealed class GetRentalQueryHandler(IReadRepositoryBase<Core.Entities.Rental> repository)
    : IRequestHandler<GetRentalQuery, Result<RentalDto>>
{
    public async Task<Result<RentalDto>> Handle(GetRentalQuery request, CancellationToken cancellationToken)
    {
        var spec = new RentalById(request.Id);
        var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);
        return Result.Success(entity.Adapt<RentalDto>());
    }
}
