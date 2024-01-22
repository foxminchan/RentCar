// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;

namespace RentCar.Infrastructure.Cloudinary;

public sealed class CloudinaryValidator : AbstractValidator<CloudinarySetting>
{
    public CloudinaryValidator()
    {
        RuleFor(x => x.CloudName)
            .NotEmpty()
            .WithMessage("CloudName is required");

        RuleFor(x => x.ApiKey)
            .NotEmpty()
            .WithMessage("ApiKey is required");

        RuleFor(x => x.ApiSecret)
            .NotEmpty()
            .WithMessage("ApiSecret is required");
    }
}
