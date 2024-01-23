// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;

namespace RentCar.Infrastructure.Abstraction.Commands.DeleteEntityCommand;

public class DeleteEntityCommandHandler<TCommand, TEntity>(IRepositoryBase<TEntity> repository)
    : ICommandHandler<TCommand, Result>
    where TCommand : DeleteEntityCommand
    where TEntity : EntityBase<Guid>
{
    public async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(request.Id, nameof(request.Id));
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);
        await repository.DeleteAsync(entity, cancellationToken);
        return Result.Success();
    }
}
