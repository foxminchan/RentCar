// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Integration.Test.Fakers;
using RentCar.Integration.Test.Fixtures;

namespace RentCar.Integration.Test.Vehicle;

public sealed class GetVehicles : BaseEfRepository
{
    private readonly VehicleFaker _faker = new();

    [Fact]
    public async Task ShouldGetVehicles()
    {
        var repository = VehicleRepository();
        var vehicles = _faker.Generate(10);

        await repository.AddRangeAsync(vehicles);

        var result = await repository.ListAsync();

        Assert.NotNull(result);
        Assert.Equal(10, result.Count);
    }
}
