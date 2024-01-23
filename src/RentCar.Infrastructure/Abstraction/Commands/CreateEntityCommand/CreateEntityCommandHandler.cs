// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Mapster;

namespace RentCar.Infrastructure.Abstraction.Commands.CreateEntityCommand;

public class CreateEntityCommandHandler<TCommand, TEntity>(IRepositoryBase<TEntity> repository)
    : ICommandHandler<TCommand, Result<Guid>>
    where TCommand : CreateEntityCommand
    where TEntity : EntityBase<Guid>
{
    public async Task<Result<Guid>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<TEntity>();
        var result = await repository.AddAsync(entity, cancellationToken);
        return Result.Success(result.Id);
    }
}
