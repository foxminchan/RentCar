// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentAssertions;

namespace RentCar.Unit.Test.Specifications;

public sealed class SpecificationBase
{
    [Fact]
    public void ShouldReturnPageNumber()
    {
        const long pageNumber = 1;
        const long pageSize = 10;
        const string sort = "Id";
        const bool isSortAscending = false;

        var spec = new Core.Specifications.SpecificationBase(
            pageNumber, pageSize, sort, isSortAscending);

        spec.PageNumber.Should().Be(pageNumber);
    }
}
