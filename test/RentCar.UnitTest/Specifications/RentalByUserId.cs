// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Entities;

namespace RentCar.Unit.Test.Specifications;

public sealed class RentalByUserId
{
    [Fact]
    public void ShouldReturnRentalByUserId()
    {
        var userId = Guid.NewGuid();
        const long pageNumber = 1;
        const long pageSize = 10;
        const string sort = "Id";
        const bool isSortAscending = false;

        var spec = new Core.Specifications.Rental.RentalByUserId(userId, new(pageNumber, pageSize, sort, isSortAscending));

        var result = spec.IsSatisfiedBy(new Rental
        {
            UserId = userId
        });

        Assert.True(result);
    }
}
