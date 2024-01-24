// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Entities;

namespace RentCar.Unit.Test.Specifications;

public sealed class VehicleById
{
    [Fact]
    public void ShouldReturnVehicleById()
    {
        var vehicleId = Guid.NewGuid();

        var spec = new Core.Specifications.Vehicle.VehicleById(vehicleId);

        var result = spec.IsSatisfiedBy(new Vehicle
        {
            Id = vehicleId
        });

        Assert.True(result);
    }

}
