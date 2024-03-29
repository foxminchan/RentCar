﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Infrastructure.Data;
using RentCar.Unit.Test.Fakers;

namespace RentCar.Unit.Test.Services.VehicleTest;

public class DeleteVehicleService
{
    private readonly Repository<Vehicle> _repository = Substitute.For<Repository<Vehicle>>();
    private readonly VehicleFaker _faker = new();

    [Fact]
    public async Task InvokesDeleteVehicleAsync()
    {
        var vehicle = _faker.Generate();
        await _repository.AddAsync(vehicle);
        await _repository.Received().DeleteAsync(vehicle);
    }
}
