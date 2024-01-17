// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Text.Json;
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

        if (validators.Any())
            await Task.WhenAll(
                validators.Select(v =>
                    v.HandleValidationAsync(request)));

        var response = await next();

        logger.LogInformation(
            "Handled {FullName} with content {Response}",
            typeof(TResponse).FullName, JsonSerializer.Serialize(response));

        return response;
    }
}
