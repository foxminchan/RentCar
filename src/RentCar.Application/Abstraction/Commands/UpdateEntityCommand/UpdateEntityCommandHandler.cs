// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Mapster;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Abstraction.Commands.UpdateEntityCommand;

public class UpdateEntityCommandHandler<TCommand, TEntity>(Repository<TEntity> repository)
    : ICommandHandler<TCommand, Result>
    where TCommand : UpdateEntityCommand
    where TEntity : EntityBase<Guid>
{
    public async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<TEntity>();
        Guard.Against.NullOrEmpty(entity.Id, nameof(entity.Id));
        var existItem = await repository.GetByIdAsync(entity.Id, cancellationToken);
        Guard.Against.NotFound(entity.Id, existItem);
        await repository.UpdateAsync(entity, cancellationToken);
        return Result.Success();
    }
}
