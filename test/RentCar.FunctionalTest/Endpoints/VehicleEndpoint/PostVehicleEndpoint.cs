// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RentCar.Core.Enums;
using RentCar.Functional.Test.Extensions;
using RentCar.Functional.Test.Fixtures;

namespace RentCar.Functional.Test.Endpoints.VehicleEndpoint;

public class PostVehicleEndpoint(ApplicationFactory<Program> factory)
    : IClassFixture<ApplicationFactory<Program>>, IAsyncLifetime
{
    private readonly ApplicationFactory<Program> _factory = factory.WithDbContainer();

    public async Task InitializeAsync()
    {
        await _factory.StartContainersAsync();
        await _factory.EnsureCreatedAsync();
    }

    public async Task DisposeAsync() => await _factory.StopContainersAsync();

    [Fact]
    public async Task ShouldReturnCreated()
    {
        var client = _factory.CreateClient();

        var faker = new Faker();

        var response = await client.PostAsJsonAsync("/api/vehicle", new
        {
            Name = faker.Vehicle.Model(),
            Brand = faker.Vehicle.Manufacturer(),
            Color = "Red",
            Plate = faker.Random.Replace("##?-###.##"),
            Type = faker.PickRandom<VehicleType>(),
            Status = faker.PickRandom<CarStatus>(),
        });

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Theory(DisplayName = "Should return bad request with invalid data")]
    [ClassData(typeof(PostData))]
    public async Task ShouldReturnBadRequest(object data)
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/vehicle", data);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}

internal sealed class PostData : TheoryData<object>
{
    public PostData()
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
