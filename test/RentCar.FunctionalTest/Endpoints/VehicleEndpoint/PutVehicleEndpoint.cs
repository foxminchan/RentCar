// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RentCar.Core.Enums;
using RentCar.Functional.Test.Extensions;
using RentCar.Functional.Test.Fakers;
using RentCar.Functional.Test.Fixtures;

namespace RentCar.Functional.Test.Endpoints.VehicleEndpoint;

public sealed class PutVehicleEndpoint(ApplicationFactory<Program> factory)
    : IClassFixture<ApplicationFactory<Program>>, IAsyncLifetime
{
    private readonly ApplicationFactory<Program> _factory = factory.WithDbContainer();
    private readonly VehicleFaker _faker = new();

    public async Task InitializeAsync()
    {
        await _factory.StartContainersAsync();
        var vehicles = _faker.Generate(1);
        await _factory.EnsureCreatedAndPopulateDataAsync(vehicles);
    }

    public async Task DisposeAsync() => await _factory.StopContainersAsync();

    [Fact]
    public async Task ShouldReturnOkAndUpdated()
    {
        var client = _factory.CreateClient();

        var id = _faker.Generate(1)[0].Id;

        var faker = new Faker();

        var response = await client.PutAsJsonAsync($"/api/vehicle/{id}", new
        {
            Name = faker.Vehicle.Model(),
            Brand = faker.Vehicle.Manufacturer(),
            Color = "Green",
            Plate = faker.Random.Replace("##?-###.##"),
            Type = faker.PickRandom<VehicleType>(),
            Status = faker.PickRandom<CarStatus>(),
        });

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}

internal sealed class PutData : TheoryData<object>
{
    public PutData()
    {
        var faker = new Faker();

        Add(new
        {
            Name = string.Empty,
            Brand = faker.Vehicle.Manufacturer(),
            Color = string.Empty,
            Plate = faker.Random.Replace("##?-###.##"),
            Type = faker.PickRandom<VehicleType>(),
            Status = faker.PickRandom<CarStatus>(),
        });

        Add(new
        {
            Name = faker.Vehicle.Model(),
            Brand = string.Empty,
            Color = string.Empty,
            Plate = faker.Random.Replace("##?-###.##"),
            Type = faker.PickRandom<VehicleType>(),
            Status = faker.PickRandom<CarStatus>(),
        });

        Add(new
        {
            Name = faker.Vehicle.Model(),
            Brand = faker.Vehicle.Manufacturer(),
            Color = string.Empty,
            Plate = faker.Random.Replace("##?-###.##"),
            Type = faker.PickRandom<VehicleType>(),
            Status = faker.PickRandom<CarStatus>(),
        });

        Add(new
        {
            Name = faker.Vehicle.Model(),
            Plate = string.Empty,
            Type = faker.PickRandom<VehicleType>(),
            Status = faker.PickRandom<CarStatus>(),
        });
    }
}
