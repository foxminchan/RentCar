// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace RentCar.Infrastructure.Logging;

public sealed class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        Guard.Against.Null(request);

        const string prefix = nameof(LoggingBehavior<TRequest, TResponse>);

        logger.LogInformation("[{Prefix}] Handling {X-RequestData}", prefix, typeof(TRequest).Name);

        var timer = new Stopwatch();

        timer.Start();

        var response = await next();

        timer.Stop();

        var timeTaken = timer.Elapsed;

        if (timeTaken.Seconds > 3)
            logger.LogWarning("[{Perf-Possible}] The request {X-RequestData} took {TimeTaken} seconds.",
                prefix, typeof(TRequest).Name, timeTaken.Seconds);

        logger.LogInformation("[{Prefix}] Handled {X-RequestData}", prefix, typeof(TRequest).Name);
        return response;
    }
}
