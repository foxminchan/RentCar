// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Rental;

public sealed class RentalFilterPaginated : Specification<Entities.Rental>
{
    public RentalFilterPaginated(int skip, int take, string orderBy)
    {
        Query.Skip(skip);
        Query.Take(take);
        Query.OrderBy(x => x.GetType().GetProperty(orderBy)!.GetValue(x, null));
    }
}
