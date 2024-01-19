﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Asp.Versioning.ApiExplorer;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RentCar.Infrastructure.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RentCar.Infrastructure.Swagger;

public static class Extension
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services)
        => services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
            .AddFluentValidationRulesToSwagger()
            .AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                    if (description.IsDeprecated)
                        new OpenApiInfo().Description += " NOTE: This API version has been deprecated.";
                options.SchemaFilter<EnumSchemaFilter>();
                options.OperationFilter<SwaggerDefaultValues>();
            })
            .Configure<SwaggerGeneratorOptions>(o => o.InferSecuritySchemes = false);
}
