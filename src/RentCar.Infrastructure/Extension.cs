// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Filters;
using RentCar.Infrastructure.HealthCheck;
using RentCar.Infrastructure.Logging;
using RentCar.Infrastructure.Swagger;
using RentCar.Infrastructure.Versioning;

namespace RentCar.Infrastructure;

public static class Extension
{
    public static void AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.AddHealthCheck();
        builder.AddApiVersioning();
        builder.AddSerilog(builder.Environment.ApplicationName);

        services
            .AddOpenApi()
            .AddProblemDetails()
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

        app.UseOpenApi();

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
