// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Maintenance;

public sealed class MaintenanceFilterPaginated : Specification<Entities.Maintenance>
{
    public MaintenanceFilterPaginated(SpecificationBase spec)
    {
        Query.Take((int)spec.PageSize);
        Query.Skip((int)((spec.PageNumber - 1) * spec.PageSize));

        if (spec.IsAscending)
            Query.OrderBy(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
        else
            Query.OrderByDescending(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
    }
}
