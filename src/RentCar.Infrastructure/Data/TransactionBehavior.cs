// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Core.Interfaces;
using System.Data;

namespace RentCar.Infrastructure.Data;

public sealed class TransactionBehavior<TRequest, TResponse>(IDatabaseFacade databaseFacade) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is not ITransactionRequest)
            return await next();

        var strategy = databaseFacade.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await databaseFacade.Database
                .BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            var response = await next();
            await transaction.CommitAsync(cancellationToken);
            return response;
        }).ConfigureAwait(false);
    }
}
