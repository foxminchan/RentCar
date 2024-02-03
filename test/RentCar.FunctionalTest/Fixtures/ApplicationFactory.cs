// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RentCar.Functional.Test.Extensions;
using Testcontainers.PostgreSql;

namespace RentCar.Functional.Test.Fixtures;

public sealed class ApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram>, IAsyncLifetime where TProgram : class
{
    private readonly List<IContainer> _containers = [];

    public WebApplicationFactory<TProgram> Instance { get; private set; } = default!;

    public Task InitializeAsync()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Test";
        Instance = WithWebHostBuilder(builder => builder.UseEnvironment(env));

        if (env.Equals(Environments.Development, StringComparison.OrdinalIgnoreCase))
            TestcontainersSettings.Logger = new NullLogger<ILoggerFactory>();
        
        return Task.CompletedTask;
    }

    public new Task DisposeAsync()
        => Task
            .WhenAll(_containers.Select(container => container.DisposeAsync().AsTask()))
            .ContinueWith(async _ => await base.DisposeAsync());

    public ApplicationFactory<TProgram> WithDbContainer()
    {
        _containers.Add(new PostgreSqlBuilder()
            .WithDatabase($"test_db_{Guid.NewGuid()}")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .WithImage("postgres:alpine")
            .WithCleanUp(true)
            .Build());

        return this;
    }

    public async Task StartContainersAsync(CancellationToken cancellationToken = default)
    {
        if (_containers.Count == 0)
            return;

        await Task.WhenAll(_containers.Select(container => container.StartWithWaitAndRetryAsync(cancellationToken: cancellationToken)));

        Instance = _containers.Aggregate(this as WebApplicationFactory<TProgram>, (current, container) => current.WithWebHostBuilder(builder =>
        {
            if (container is PostgreSqlContainer dbContainer)
                builder.UseSetting("ConnectionStrings:DefaultConnection", dbContainer.GetConnectionString());
        }));
    }

    public new HttpClient CreateClient() => Instance.CreateClient();

    public async Task<HttpClient> StopContainersAsync()
    { 
        if (_containers.Count == 0)
            return Instance.CreateClient();

        await Task.WhenAll(_containers.Select(container => container.DisposeAsync().AsTask()))
            .ContinueWith(async _ => await base.DisposeAsync())
            .ContinueWith(async _ => await InitializeAsync())
            .ConfigureAwait(false);

        return Instance.CreateClient();
    }
}
