// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RentCar.Infrastructure.Swagger;

public sealed class ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
    : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
            options.SwaggerDoc(description.GroupName,
                new()
                {
                    Title = "Rent Car API",
                    Version = description.ApiVersion.ToString(),
                    Description =
                        "Streamlined car rental management, including reservation, fleet admin, and payment features",
                    License = new() { Name = "MIT", Url = new("https://opensource.org/licenses/MIT") },
                    Contact = new() { Name = "Nguyen Xuan Nhan", Email = "nguyenxuannhan407@gmail.com" },
                });
    }
}
