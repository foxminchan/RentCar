﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Net.Security;

using Ardalis.GuardClauses;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RentCar.Infrastructure.HealthCheck;

public static class Extension
{
    public static WebApplicationBuilder AddHealthCheck(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        builder.Services.AddHealthChecks().AddNpgSql(connectionString, tags: ["database"]);

        builder.Services
            .AddHealthChecksUI(options =>
            {
                options.AddHealthCheckEndpoint("Health Check API", "/hc");
                options.SetEvaluationTimeInSeconds(60);
                options.SetApiMaxActiveRequests(1);
                options.DisableDatabaseMigrations();
                options.MaximumHistoryEntriesPerEndpoint(50);
                options.SetNotifyUnHealthyOneTimeUntilChange();
                options.UseApiEndpointHttpMessageHandler(_ => new()
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback = (_, _, _, sslPolicyErrors) => sslPolicyErrors == SslPolicyErrors.None
                });
            })
            .AddInMemoryStorage();

        return builder;
    }

    public static void MapHealthCheck(this WebApplication app)
    {
        app.MapHealthChecks("/hc",
            new()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                AllowCachingResponses = false,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
            });
        app.MapHealthChecksUI(options => options.UIPath = "/hc-ui");
    }
}
