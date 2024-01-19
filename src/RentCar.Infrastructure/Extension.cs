// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Filters;
using RentCar.Infrastructure.HealthCheck;
using RentCar.Infrastructure.Logging;
using RentCar.Infrastructure.Swagger;

namespace RentCar.Infrastructure;

public static class Extension
{
    public static void AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.AddHealthCheck();
        builder.AddSerilog(builder.Environment.ApplicationName);

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.AddServerHeader = false;
            options.AllowResponseHeaderCompression = true;
            options.ConfigureEndpointDefaults(o => o.Protocols = HttpProtocols.Http1AndHttp2AndHttp3);
        });

        services
            .AddOpenApi()
            .AddProblemDetails()
            .AddEndpointsApiExplorer()
            .AddHttpContextAccessor();

        services.AddPostgres(builder.Configuration);

        services.AddSingleton<IDeveloperPageExceptionFilter, DeveloperPageExceptionFilter>();
    }

    public static async Task UseWebInfrastructureAsync(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
            await initializer.InitialiseAsync();
            await initializer.SeedAsync();
        }

        app
            .UseAuthentication()
            .UseAuthorization();

        app.MapHealthCheck();
        app.Map("/", () => Results.Redirect("/swagger"));
        app.Map("/error",
                () => Results.Problem("An unexpected error occurred.", statusCode: StatusCodes.Status500InternalServerError))
            .ExcludeFromDescription();
    }
}
