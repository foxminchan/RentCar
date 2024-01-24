// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RentCar.Application.Vehicle.Dto;
using RentCar.Functional.Test.Endpoints.Fakers;
using RentCar.Functional.Test.Extensions;
using RentCar.Functional.Test.Fixtures;

namespace RentCar.Functional.Test.Endpoints.VehicleEndpoint;

public class GetVehiclesEndpoint(ApplicationFactory<Program> factory) 
    : IClassFixture<ApplicationFactory<Program>>, IAsyncLifetime
{
    private readonly ApplicationFactory<Program> _factory = factory.WithDbContainer();
    private readonly VehicleFaker _faker = new();

    public async Task InitializeAsync()
    {
        await _factory.StartContainersAsync();
        var vehicles = _faker.Generate(10);
        await _factory.EnsureCreatedAndPopulateDataAsync(vehicles);
    }

    public async Task DisposeAsync() => await _factory.StopContainersAsync();


    [Fact]
    public async Task ShouldReturnAllVehicles()
    {
        var client = _factory.CreateClient();

        var query = new Dictionary<string, string>
        {
            ["PageNumber"] = "1",
            ["PageSize"] = "10",
            ["OrderBy"] = "Id",
            ["IsAscending"] = "true"
        };

        var response = await client.GetAsync(QueryHelpers.AddQueryString("/vehicles", query!));

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var vehicles = await response.Content.ReadFromJsonAsync<IReadOnlyList<VehicleDto>>();

        vehicles.Should().NotBeEmpty();
        vehicles.Should().HaveCount(10);
    }
}
