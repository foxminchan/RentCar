// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Integration.Test.Fakers;
using RentCar.Integration.Test.Fixtures;

namespace RentCar.Integration.Test.Vehicle;

public sealed class DeleteVehicle : BaseEfRepository
{
    private readonly VehicleFaker _faker = new();

    [Fact]
    public async Task ShouldDeleteVehicle()
    {
        var repository = VehicleRepository();
        var vehicle = _faker.Generate();

        await repository.AddAsync(vehicle);

        var result = (await repository.ListAsync()).FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(vehicle.Id, result.Id);

        await repository.DeleteAsync(vehicle);

        result = (await repository.ListAsync()).FirstOrDefault();

        Assert.Null(result);
    }
}
