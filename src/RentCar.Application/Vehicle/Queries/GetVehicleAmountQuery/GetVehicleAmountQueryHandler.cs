// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;

namespace RentCar.Application.Vehicle.Queries.GetVehicleAmountQuery;

public sealed class GetVehicleAmountQueryHandler(IReadRepositoryBase<Core.Entities.Vehicle> repository) 
    : IQueryHandler<GetVehicleAmountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetVehicleAmountQuery request, CancellationToken cancellationToken)
        => await repository.CountAsync(cancellationToken);
}
