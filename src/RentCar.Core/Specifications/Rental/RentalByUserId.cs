// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Rental;

public sealed class RentalByUserId : Specification<Entities.Rental>
{
    public RentalByUserId(string userId)
    {
        Query.Where(x => x.UserId == userId);
    }
}
