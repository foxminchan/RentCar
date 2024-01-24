// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Core.Enums;
using RentCar.Infrastructure.Data;

namespace RentCar.Unit.Test.Services.VehicleTest;

public class DeleteVehicleService
{
    private readonly Repository<Vehicle> _repository = Substitute.For<Repository<Vehicle>>();

    [Fact]
    public async Task InvokesDeleteVehicleAsync()
    {
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Brand = "Test",
            Color = "Test",
            Status = CarStatus.Available,
            Type = VehicleType.Suv,
            Image = "https://localhost:5001/images/vehicles/1.jpg",
        };

        await _repository.AddAsync(vehicle);
        await _repository.Received().DeleteAsync(vehicle);
    }
}
