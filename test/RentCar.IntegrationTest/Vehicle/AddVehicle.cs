// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Bogus;
using RentCar.Core.Enums;
using RentCar.Integration.Test.Fixtures;

namespace RentCar.Integration.Test.Vehicle;

public sealed class AddVehicle : BaseEfRepository
{

    [Fact]
    public async Task ShouldAddVehicle()
    {
        var repository = VehicleRepository();
        var faker = new Faker();
        var vehicle = new Core.Entities.Vehicle
        {
            Id = Guid.NewGuid(),
            Name = faker.Vehicle.Model(),
            Brand = faker.Vehicle.Manufacturer(),
            Color = "White",
            Image = faker.Image.PicsumUrl(700, 700),
            Status = faker.PickRandom<CarStatus>(),
            Type = faker.PickRandom<VehicleType>(),
            Plate = faker.Random.Replace("##?-###.##")
        };

        await repository.AddAsync(vehicle);

        var result = (await repository.ListAsync()).FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(vehicle.Id, result.Id);
    }
}
