// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentAssertions;
using System.Net;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RentCar.Functional.Test.Fixtures;

namespace RentCar.Functional.Test.Endpoints.HealthCheckEndpoint;

public sealed class HealthCheckReady(ApplicationFactory<Program> factory) 
    : IClassFixture<ApplicationFactory<Program>>
{
    [Fact]
    public async Task ShouldReturnOk()
    {
        try
        {
            await factory
                .WithDbContainer()
                .StartContainersAsync();

            var client = factory.CreateClient();

            var response = await client.GetAsync("/hc/ready");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        finally
        {
            await factory.StopContainersAsync();
        }
    }

    [Fact]
    public async Task ShouldReturnInternalServerError()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/hc/ready");

        response.StatusCode.Should().Be(HttpStatusCode.ServiceUnavailable);
    }
}
