// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Filters;
using RentCar.Infrastructure.HealthCheck;
using RentCar.Infrastructure.Logging;

namespace RentCar.Infrastructure;

public static class Extension
{
    public static void AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.AddHealthCheck();
        builder.AddSerilog(builder.Environment.ApplicationName);

        services
            .AddProblemDetails()
            .AddHttpContextAccessor();

        services.AddPostgres(builder.Configuration);

        services.AddSingleton<IDeveloperPageExceptionFilter, DeveloperPageExceptionFilter>();
    }

    public static void UseWebInfrastructure(this WebApplication app)
    {
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
