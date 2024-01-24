// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Integration.Test.Fakers;
using RentCar.Integration.Test.Fixtures;

namespace RentCar.Integration.Test.Vehicle;

public sealed class UpdateVehicle : BaseEfRepository
{
    private readonly VehicleFaker _faker = new();

    [Fact]
    public async Task ShouldUpdateVehicle()
    {
        var repository = VehicleRepository();
        var vehicle = _faker.Generate();

        await repository.AddAsync(vehicle);

        var result = (await repository.ListAsync()).FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(vehicle.Id, result.Id);

        vehicle.Name = "Updated Name";
        vehicle.Brand = "Updated Brand";
        vehicle.Color = "Updated Color";
        vehicle.Image = "Updated Image";
        vehicle.Plate = "Updated Plate";

        await repository.UpdateAsync(vehicle);

        result = (await repository.ListAsync()).FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(vehicle.Id, result.Id);
        Assert.Equal(vehicle.Name, result.Name);
        Assert.Equal(vehicle.Brand, result.Brand);
        Assert.Equal(vehicle.Color, result.Color);
        Assert.Equal(vehicle.Image, result.Image);
        Assert.Equal(vehicle.Plate, result.Plate);
    }
}
