// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Maintenance;

public sealed class MaintenanceByVehicleId : Specification<Entities.Maintenance>
{
    public MaintenanceByVehicleId(Guid vehicleId, SpecificationBase spec)
    {
        Query.Take((int)spec.PageSize);
        Query.Skip((int)((spec.PageNumber - 1) * spec.PageSize));
        Query.Where(x => x.VehicleId == vehicleId);

        if (spec.IsAscending)
            Query.OrderBy(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
        else
            Query.OrderByDescending(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
    }
}
