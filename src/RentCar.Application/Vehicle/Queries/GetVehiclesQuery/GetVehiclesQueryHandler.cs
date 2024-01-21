// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Mapster;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.Specifications.Vehicle;

namespace RentCar.Application.Vehicle.Queries.GetVehiclesQuery;

public sealed class GetVehiclesQueryHandler(IReadRepositoryBase<Core.Entities.Vehicle> repository)
    : IQueryHandler<GetVehiclesQuery, Result<IEnumerable<VehicleDto>>>
{
    public async Task<Result<IEnumerable<VehicleDto>>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var spec = new VehicleFilterPaginated(request.Skip, request.Take, request.OrderBy);
        var entities = await repository.ListAsync(spec, cancellationToken);
        return Result.Success(entities.Adapt<IEnumerable<VehicleDto>>());
    }
}
