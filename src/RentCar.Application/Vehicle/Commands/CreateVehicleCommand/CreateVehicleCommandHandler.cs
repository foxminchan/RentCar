// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using FluentValidation;
using Mapster;

namespace RentCar.Application.Vehicle.Commands.CreateVehicleCommand;

public sealed class CreateVehicleCommandHandler(IRepositoryBase<Core.Entities.Vehicle> repository)
    : ICommandHandler<CreateVehicleCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Vehicle>();
        var result = await repository.AddAsync(entity, cancellationToken);
        return Result.Success(result.Id);
    }
}

public sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters");

        RuleFor(x => x.Brand)
            .NotEmpty()
            .WithMessage("Brand is required")
            .MaximumLength(50)
            .WithMessage("Brand must not exceed 50 characters");

        RuleFor(x => x.Color)
            .NotEmpty()
            .WithMessage("Color is required")
            .MaximumLength(20)
            .WithMessage("Color must not exceed 20 characters");

        RuleFor(x => x.Plate)
            .NotEmpty()
            .WithMessage("Plate is required")
            .MaximumLength(10)
            .WithMessage("Plate must not exceed 10 characters");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Type must be in enum");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status must be in enum");

        RuleFor(x => x.Image)
            .MaximumLength(255)
            .WithMessage("Image Url must not exceed 255 characters");
    }
}
