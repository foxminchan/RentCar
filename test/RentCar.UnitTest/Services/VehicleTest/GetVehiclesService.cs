﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Core.Specifications.Vehicle;
using RentCar.Infrastructure.Data;
using RentCar.Unit.Test.Fakers;

namespace RentCar.Unit.Test.Services.VehicleTest;

public sealed class GetVehiclesService
{
    private readonly Repository<Vehicle> _repository = Substitute.For<Repository<Vehicle>>();
    private readonly VehicleFaker _faker = new();

    [Fact]
    public async Task InvokesGetVehiclesAsync()
    {
        var vehicles = _faker.Generate(20);
        await _repository.AddRangeAsync(vehicles);
        await _repository.Received().ListAsync(Arg.Any<VehicleFilterPaginated>(), Arg.Any<CancellationToken>());
    }
}
