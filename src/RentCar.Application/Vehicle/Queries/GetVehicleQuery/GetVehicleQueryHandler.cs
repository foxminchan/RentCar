// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.Specification;
using Mapster;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.SharedKernel;
using RentCar.Core.Specifications.Vehicle;

namespace RentCar.Application.Vehicle.Queries.GetVehicleQuery;

public class GetVehicleQueryHandler(IReadRepositoryBase<Core.Entities.Vehicle> repository) 
    : IQueryHandler<GetVehicleQuery, Result<VehicleDto>>
{
    public async Task<Result<VehicleDto>> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
    {
        var spec = new VehicleById(request.Id);
        var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);
        return Result.Success(entity.Adapt<VehicleDto>());
    }
}
