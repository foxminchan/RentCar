// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Vehicle;

public sealed class VehicleById : Specification<Entities.Vehicle>
{
    public VehicleById(Guid id)
    {
        Query.Where(x => x.Id == id);
    }
}
