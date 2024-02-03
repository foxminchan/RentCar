// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Core.Enums;
using RentCar.Infrastructure.Data;
using RentCar.Unit.Test.Fakers;

namespace RentCar.Unit.Test.Services.VehicleTest;

public sealed class UpdateVehicleService
{
    private readonly Repository<Vehicle> _repository = Substitute.For<Repository<Vehicle>>();
    private readonly VehicleFaker _faker = new();

    [Fact]
    public async Task InvokesUpdateVehicleAsync()
    {
        var vehicle = _faker.Generate();
        await _repository.UpdateAsync(vehicle);
        var existVehicle = (await _repository.ListAsync()).FirstOrDefault();
        Assert.NotNull(existVehicle);
        existVehicle.Status = CarStatus.Lost;
        await _repository.Received().UpdateAsync(existVehicle, Arg.Any<CancellationToken>());
    }
}
