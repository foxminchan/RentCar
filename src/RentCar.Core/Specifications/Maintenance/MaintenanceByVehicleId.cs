// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Linq.Expressions;
using Ardalis.Specification;

namespace RentCar.Core.Specifications.Maintenance;

public sealed class MaintenanceByVehicleId : Specification<Entities.Maintenance>
{
    public MaintenanceByVehicleId(Guid vehicleId, SpecificationBase spec)
    {
        Query.Take((int)spec.PageSize);
        Query.Skip((int)((spec.PageNumber - 1) * spec.PageSize));
        Query.Where(x => x.VehicleId == vehicleId);
        Query.Include(x => x.Vehicle);

        var parameter = Expression.Parameter(typeof(Entities.Maintenance), "x");
        var property = Expression.Property(parameter, spec.OrderBy ?? "Id");
        var lambda = Expression.Lambda<Func<Entities.Maintenance, object>>(Expression.Convert(property, typeof(object)), parameter);

        if (spec.IsAscending)
            Query.OrderBy(lambda!);
        else
            Query.OrderByDescending(lambda!);
    }
}
