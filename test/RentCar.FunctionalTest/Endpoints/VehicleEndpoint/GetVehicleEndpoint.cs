// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentAssertions;
using System.Net.Http.Json;
using System.Net;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RentCar.Application.Vehicle.Dto;
using RentCar.Functional.Test.Extensions;
using RentCar.Functional.Test.Fixtures;
using RentCar.Functional.Test.Fakers;

namespace RentCar.Functional.Test.Endpoints.VehicleEndpoint;

public sealed class GetVehicleEndpoint(ApplicationFactory<Program> factory)
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
    public async Task ShouldReturnVehicle()
    {
        var client = _factory.CreateClient();

        var id = _faker.Generate(1)[0].Id;

        var response = await client.GetAsync($"/api/vehicle/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var vehicles = await response.Content.ReadFromJsonAsync<VehicleDto>();

        vehicles.Should().NotBeNull()
            .And.Match<VehicleDto>(x => x.Id == id);
    }

    [Theory(DisplayName = "Should return 404 with invalid id")]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public async Task ShouldReturnNotFound(Guid id)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"/api/vehicle/{id}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
