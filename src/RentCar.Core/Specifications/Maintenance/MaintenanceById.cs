// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Maintenance;

public sealed class MaintenanceById : Specification<Entities.Maintenance>
{
    public MaintenanceById(Guid id)
    {
        Query.Where(x => x.Id == id);
    }
}
