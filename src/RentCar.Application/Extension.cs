// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Validator;
using System.Reflection.Metadata;
using Quartz;
using RentCar.Application.Rental.Jobs;

namespace RentCar.Application;

public static class Extension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies([typeof(AssemblyReference).Assembly]);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>),
                    ServiceLifetime.Scoped);
            });

        services.AddQuartz(options =>
        {
            var jobKey = new JobKey(nameof(RentalExpirationService));

            options.AddJob<RentalExpirationService>(jobKey)
                .AddTrigger(
                    trigger => trigger
                        .ForJob(jobKey)
                        .WithSimpleSchedule(schedule => schedule
                            .WithIntervalInHours(12)
                            .RepeatForever()
                        )
                );
        });

        services.AddQuartzHostedService(options =>
            options.WaitForJobsToComplete = true
        );
    }
}
