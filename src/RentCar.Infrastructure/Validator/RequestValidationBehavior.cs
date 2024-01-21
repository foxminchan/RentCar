// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Text.Json;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RentCar.Infrastructure.Validator;

public sealed class RequestValidationBehavior<TRequest, TResponse>(
    IServiceProvider serviceProvider,
    ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "[{Prefix}] Handle request={X-RequestData} and response={X-ResponseData}",
            nameof(RequestValidationBehavior<TRequest, TResponse>), typeof(TRequest).Name, typeof(TResponse).Name);

        logger.LogDebug(
            "Handled {Request} with content {X-RequestData}",
            typeof(TRequest).FullName, JsonSerializer.Serialize(request));

        var validators = serviceProvider
                             .GetService<IEnumerable<IValidator<TRequest>>>()?.ToList()
                         ?? throw new InvalidOperationException();

        if (validators.Count != 0)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));
            var resultErrors = validationResults.SelectMany(e => e.AsErrors()).ToList();
            var failures = validationResults.SelectMany(x => x.Errors).Where(x => x is { }).ToList();

            if (failures.Count != 0)
            {
                if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var result = typeof(TResponse).GetGenericArguments()[0];
                    var invalidMethod = typeof(Result).MakeGenericType(result)
                        .GetMethod(nameof(Result<int>.Invalid), [typeof(List<ValidationError>)]);

                    if (invalidMethod is { })
                        return (TResponse)invalidMethod.Invoke(null, [resultErrors])!;
                }
                else
                {
                    return typeof(TResponse) == typeof(Result)
                        ? (TResponse)(object)Result.Invalid(resultErrors)
                        : throw new ValidationException(failures);
                }
            }
        }

        var response = await next();

        logger.LogInformation(
            "Handled {FullName} with content {Response}",
            typeof(TResponse).FullName, JsonSerializer.Serialize(response));

        return response;
    }
}
