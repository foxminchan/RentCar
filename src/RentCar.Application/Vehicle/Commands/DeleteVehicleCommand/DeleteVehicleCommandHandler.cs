// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using FluentValidation;
using RentCar.Infrastructure.Cloudinary;

namespace RentCar.Application.Vehicle.Commands.DeleteVehicleCommand;

public sealed class DeleteVehicleCommandHandler(
    IRepositoryBase<Core.Entities.Vehicle> repository,
    ICloudinaryService cloudinaryService)
    : ICommandHandler<DeleteVehicleCommand, Result>
{
    public async Task<Result> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Null(request.Id, nameof(request));
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        if (entity.Image is { })
            await cloudinaryService.DeletePhotoAsync(entity.Image);

        await repository.DeleteAsync(entity, cancellationToken);
        return Result.Success();
    }
}

public sealed class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
{
    public DeleteVehicleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
