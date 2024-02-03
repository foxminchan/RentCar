// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RentCar.Infrastructure.Data.Interceptors;

public sealed class DispatchDomainEventsInterceptor(IDomainEventDispatcher? dispatcher) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task DispatchDomainEvents(DbContext? context)
    {
        if (context is null)
            return;

        if (dispatcher is null)
            return;

        var entitiesWithEvents = context.ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await dispatcher.DispatchAndClearEvents(entitiesWithEvents);
    }
}
