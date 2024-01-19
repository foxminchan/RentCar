// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Diagnostics;
using System.Reflection.Metadata;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Logging;
using RentCar.Infrastructure.Validator;

namespace RentCar.Infrastructure.Mediator;

public static class Extension
{
    [DebuggerStepThrough]
    public static IServiceCollection AddMediator(
        this IServiceCollection services,
        Action<IServiceCollection>? action = null)
    {
        services.AddHttpContextAccessor()
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>),
                    ServiceLifetime.Scoped);
            });

        action?.Invoke(services);

        return services;
    }
}
