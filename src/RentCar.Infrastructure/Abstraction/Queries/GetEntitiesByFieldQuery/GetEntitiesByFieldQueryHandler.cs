// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Mapster;

namespace RentCar.Infrastructure.Abstraction.Queries.GetEntitiesByFieldQuery;

public class GetEntitiesByFieldQueryHandler<TQuery, TEntity, TResult, TSpec>(IReadRepositoryBase<TEntity> repository)
    : IQueryHandler<TQuery, PagedResult<IEnumerable<TResult>>>
    where TQuery : GetEntitiesByFieldQuery<TResult>
    where TEntity : class
    where TResult : notnull
    where TSpec : Specification<TEntity>
{
    public async Task<PagedResult<IEnumerable<TResult>>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(request.Id, nameof(request.Id));
        var spec = Activator.CreateInstance(typeof(TSpec), (request.Id, request.Spec)) as TSpec;
        Guard.Against.Null(spec, nameof(spec));
        var entities = await repository.ListAsync(spec, cancellationToken);
        var count = await repository.CountAsync(cancellationToken);
        var totalPage = (int)Math.Ceiling((double)count / request.Spec.PageSize);
        var pagedInfo = new PagedInfo(request.Spec.PageNumber, request.Spec.PageSize, totalPage, count);
        return new(pagedInfo, entities.Adapt<IEnumerable<TResult>>());
    }
}
