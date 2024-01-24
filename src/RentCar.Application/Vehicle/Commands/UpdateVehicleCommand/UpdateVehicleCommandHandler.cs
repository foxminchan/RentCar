// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Http;
using RentCar.Infrastructure.Cloudinary;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Vehicle.Commands.UpdateVehicleCommand;

public sealed class UpdateVehicleCommandHandler(
    Repository<Core.Entities.Vehicle> repository,
    ICloudinaryService cloudinaryService)
    : ICommandHandler<UpdateVehicleCommand, Result>
{
    public async Task<Result> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Vehicle>();
        var existItem = await repository.GetByIdAsync(entity.Id, cancellationToken);
        Guard.Against.NotFound(entity.Id, existItem);

        if (request.Image is null && existItem.Image is { })
            await cloudinaryService.DeletePhotoAsync(existItem.Image);

        if (request.ImageFile is { })
        {
            if (existItem.Image is { })
                await cloudinaryService.DeletePhotoAsync(existItem.Image);

            var uploadResult = await cloudinaryService.AddPhotoAsync(request.ImageFile);
            entity.Image = uploadResult.Value.Url;
        }

        await repository.UpdateAsync(entity, cancellationToken);
        return Result.Success();
    }
}

public sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

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

        RuleFor(x => x.ImageFile)
            .Must(BeAValidImage)
            .WithMessage("Invalid image format");
    }

    private static bool BeAValidImage(IFormFile? file)
    {
        if (file is null)
            return true;

        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
        var extension = Path.GetExtension(file.FileName);

        return file.Length <= 2 * 1024 * 1024
               && (!string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension.ToLower()));
    }
}
