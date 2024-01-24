// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Infrastructure.Data;

namespace RentCar.Unit.Test.Services.VehicleTest;

public sealed class CreateVehicleService
{
    private readonly Repository<Vehicle> _repository = Substitute.For<Repository<Vehicle>>();

    [Fact]
    public async Task InvokesCreateVehicleAsync()
        => await _repository.Received().AddAsync(Arg.Any<Vehicle>());
}
