﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Infrastructure.Auth;
using RentCar.Infrastructure.Cloudinary;
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

        services
            .AddOpenApi()
            .AddProblemDetails()
            .AddHttpContextAccessor()
            .AddApplicationIdentity();

        services
            .AddPostgres(builder.Configuration)
            .AddCloudinary(builder.Configuration);

        services.AddSingleton<IDeveloperPageExceptionFilter, DeveloperPageExceptionFilter>();
    }

    public static void UseWebInfrastructure(this WebApplication app)
    {
        app.MapIdentity();
        app.MapHealthCheck();
        app.UseOpenApi();
        app.Map("/", () => Results.Redirect("/swagger"));
        app.Map("/error",
                () => Results.Problem("An unexpected error occurred.", statusCode: StatusCodes.Status500InternalServerError))
            .ExcludeFromDescription();
    }
}
