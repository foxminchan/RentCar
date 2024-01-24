// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace RentCar.Functional.Test.Endpoints.HealthCheckEndpoint;

public sealed class HealthCheckLive(WebApplicationFactory<Program> factory) 
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task ShouldReturnOk()
    {
        var client = factory
            .WithWebHostBuilder(builder => builder.UseSetting("ConnectionStrings:DefaultConnection", "Host=localhost;Port=5432;Database=test_db;Username=postgres;Password=postgres")).CreateClient();

        var response = await client.GetAsync("/hc/live");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Theory]
    [InlineData("ConnectionStrings:DefaultConnection")]
    public async Task ShouldReturnInternalServerError(string key)
    {
        var client = factory
            .WithWebHostBuilder(builder => builder.UseSetting(key, string.Empty)).CreateClient();

        var response = await client.GetAsync("/hc/live");

        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}
