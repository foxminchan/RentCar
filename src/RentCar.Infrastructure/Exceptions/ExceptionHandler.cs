// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RentCar.Infrastructure.Exceptions;

public sealed class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {ExceptionMessage}", exception.Message);

        switch (exception)
        {
            case Ardalis.GuardClauses.NotFoundException notFoundException:
                await HandleNotFoundException(httpContext, notFoundException, cancellationToken);
                break;
            case UnauthorizedAccessException unauthorizedAccessException:
                await HandleUnauthorizedAccessException(httpContext, unauthorizedAccessException, cancellationToken);
                break;
            default:
                await HandleDefaultException(httpContext, cancellationToken);
                break;
        }

        return true;
    }

    private static async Task HandleNotFoundException(
        HttpContext httpContext,
        Exception notFoundException,
        CancellationToken cancellationToken)
    {
        var notFoundErrorModel = Result.Error(notFoundException.Message);
        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        await httpContext.Response.WriteAsJsonAsync(notFoundErrorModel, cancellationToken);
    }

    private static async Task HandleUnauthorizedAccessException(
        HttpContext httpContext,
        Exception unauthorizedAccessException,
        CancellationToken cancellationToken)
    {
        var unauthorizedErrorModel =
            Result.Error(unauthorizedAccessException.Message);
        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await httpContext.Response.WriteAsJsonAsync(unauthorizedErrorModel, cancellationToken);
    }

    private static async Task HandleDefaultException(
        HttpContext httpContext,
        CancellationToken cancellationToken)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
        };
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);
    }
}
