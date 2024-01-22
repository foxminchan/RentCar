// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RentCar.Infrastructure.Validator;

namespace RentCar.Infrastructure.Cloudinary;

public static class Extension
{
    public static IServiceCollection AddCloudinary(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<CloudinarySetting>()
            .Bind(configuration.GetSection(nameof(CloudinarySetting)))
            .ValidateFluentValidation()
            .ValidateOnStart();

        services.AddScoped<ICloudinaryUploadApi, CloudinaryDotNet.Cloudinary>(provider =>
        {
            var cloudinary = provider.GetRequiredService<IOptions<CloudinarySetting>>().Value;
            return new(new Account(cloudinary.CloudName, cloudinary.ApiKey, cloudinary.ApiSecret));
        });

        services.AddScoped<ICloudinaryService, CloudinaryService>();

        return services;
    }
}
