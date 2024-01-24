// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Core.Enums;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Data;

namespace RentCar.Unit.Test.Services.VehicleTest;

public sealed class GetVehiclesService
{
    private readonly Repository<Vehicle> _repository = Substitute.For<Repository<Vehicle>>();

    [Fact]
    public async Task InvokesGetVehiclesAsync()
    {
        var vehicles = new List<Vehicle>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Brand = "Test",
                Color = "Test",
                Status = CarStatus.Available,
                Type = VehicleType.Suv,
                Image = "https://localhost:5001/images/vehicles/1.jpg",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Brand = "Test",
                Color = "Test",
                Status = CarStatus.Available,
                Type = VehicleType.Suv,
                Image = "https://localhost:5001/images/vehicles/1.jpg",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Brand = "Test",
                Color = "Test",
                Status = CarStatus.Available,
                Type = VehicleType.Suv,
                Image = "https://localhost:5001/images/vehicles/1.jpg",
            }
        };

        await _repository.AddAsync(vehicles[0]);
        await _repository.AddAsync(vehicles[1]);
        await _repository.AddAsync(vehicles[2]);

        var spec = new VehicleFilterPaginated(new ());

        await _repository.Received().ListAsync(spec, Arg.Any<CancellationToken>());
    }
}
