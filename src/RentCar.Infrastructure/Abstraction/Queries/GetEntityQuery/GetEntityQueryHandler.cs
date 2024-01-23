// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Mapster;

namespace RentCar.Infrastructure.Abstraction.Queries.GetEntityQuery;

public class GetEntityQueryHandler<TQuery, TEntity, TResult, TSpec>(IReadRepositoryBase<TEntity> repository)
    : IQueryHandler<TQuery, Result<TResult>>
    where TQuery : GetEntityQuery<TResult>
    where TEntity : class
    where TResult : notnull
    where TSpec : Specification<TEntity>
{
    public async Task<Result<TResult>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(request.Id, nameof(request));
        var spec = Activator.CreateInstance(typeof(TSpec), request.Id) as TSpec;
        Guard.Against.Null(spec, nameof(spec));
        var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);
        return Result.Success(entity.Adapt<TResult>());
    }
}
