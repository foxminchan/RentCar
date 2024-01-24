// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Linq.Expressions;
using Ardalis.Specification;

namespace RentCar.Core.Specifications.Maintenance;

public sealed class MaintenanceFilterPaginated : Specification<Entities.Maintenance>
{
    public MaintenanceFilterPaginated(SpecificationBase spec)
    {
        Query.Take((int)spec.PageSize);
        Query.Skip((int)((spec.PageNumber - 1) * spec.PageSize));

        var parameter = Expression.Parameter(typeof(Entities.Maintenance), "x");
        var property = Expression.Property(parameter, spec.OrderBy ?? "Id");
        var lambda = Expression.Lambda<Func<Entities.Maintenance, object>>(Expression.Convert(property, typeof(object)), parameter);

        if (spec.IsAscending)
            Query.OrderBy(lambda!);
        else
            Query.OrderByDescending(lambda!);
    }
}
