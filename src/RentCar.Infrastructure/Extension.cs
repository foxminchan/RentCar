// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Filters;
using RentCar.Infrastructure.Logging;
using RentCar.Infrastructure.Swagger;

namespace RentCar.Infrastructure;

public static class Extension
{
    public static void AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.AddSerilog(builder.Environment.ApplicationName);

        services
            .AddOpenApi()
            .AddProblemDetails()
            .AddEndpointsApiExplorer()
            .AddHttpContextAccessor();

        services.AddPostgres(builder.Configuration);

        services.AddSingleton<IDeveloperPageExceptionFilter, DeveloperPageExceptionFilter>();
    }
}
