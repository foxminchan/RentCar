// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace RentCar.Infrastructure.Validator;

public static class Extension
{
    public static async Task HandleValidationAsync<TRequest>(this IValidator<TRequest> validator, TRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);

        var failures = validationResult
            .Errors;

        if (failures.Count != 0)
            throw new ValidationException(failures);
    }

    [DebuggerStepThrough]
    public static IServiceCollection AddValidators(this IServiceCollection services)
        => services.Scan(scan => scan
            .FromAssemblies(typeof(AssemblyReference).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
}
