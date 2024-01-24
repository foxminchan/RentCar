// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentAssertions;
using RentCar.Core.ValueObjects;

namespace RentCar.Unit.Test.ValueObjects;

public sealed class AddressTest
{
    [Fact]
    public void InvokesInitializeAddressObject()
    {
        const string street = "Nam Ky Khoi Nghia";
        const string ward = "Ben Nghe";
        const string city = "District 1";
        const string province = "Ho Chi Minh";
        var address = new Address(street, ward, city, province);
        address.Street.Should().Be(street);
    }
}
