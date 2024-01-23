// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Mapster;
using MediatR;

namespace RentCar.Infrastructure.Abstraction.Commands.UpdateEntityCommand;

public class UpdateEntityCommandHandler<TCommand, TEntity>(IRepositoryBase<TEntity> repository)
    : ICommandHandler<TCommand, Result<Unit>>
    where TCommand : UpdateEntityCommand
    where TEntity : EntityBase<Guid>
{
    public async Task<Result<Unit>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<TEntity>();
        Guard.Against.NullOrEmpty(entity.Id, nameof(entity.Id));
        var existItem = await repository.GetByIdAsync(entity.Id, cancellationToken);
        Guard.Against.NotFound(entity.Id, existItem);
        await repository.UpdateAsync(entity, cancellationToken);
        return Result.Success(Unit.Value);
    }
}
