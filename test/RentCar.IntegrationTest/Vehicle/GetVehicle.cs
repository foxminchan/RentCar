// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Integration.Test.Fakers;
using RentCar.Integration.Test.Fixtures;

namespace RentCar.Integration.Test.Vehicle;

public sealed class GetVehicle : BaseEfRepository
{
    private readonly VehicleFaker _faker = new();

    [Fact]
    public async Task ShouldGetVehicle()
    {
        var repository = VehicleRepository();
        var vehicle = _faker.Generate();

        await repository.AddAsync(vehicle);

        var result = await repository.GetByIdAsync(vehicle.Id);

        Assert.NotNull(result);
        Assert.Equal(vehicle.Id, result.Id);
    }

    [Theory(DisplayName = "Should return null with invalid id")]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public async Task ShouldReturnNullWithInvalidId(Guid id)
    {
        var repository = VehicleRepository();

        var result = await repository.GetByIdAsync(id);

        Assert.Null(result);
    }
}
