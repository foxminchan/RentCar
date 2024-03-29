﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentCar.Infrastructure.Data.CompliedModels;
using RentCar.Infrastructure.Data.Interceptors;

namespace RentCar.Infrastructure.Data;

public static class Extension
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
        services.AddScoped<IDbCommandInterceptor, TimingInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContextPool<ApplicationDbContext>((sp,options) =>
        {
            options.UseNpgsql(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(AssemblyReference.DbContext.FullName);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);
                })
                .UseExceptionProcessor()
                .EnableServiceProviderCaching()
                .UseSnakeCaseNamingConvention()
                .UseModel(ApplicationDbContextModel.Instance)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            options.AddInterceptors(sp.GetServices<IDbCommandInterceptor>());
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                options
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
        });

        services.AddScoped<IDatabaseFacade>(p => p.GetRequiredService<ApplicationDbContext>());
        services.AddScoped(typeof(Repository<>));

        return services;
    }
}
