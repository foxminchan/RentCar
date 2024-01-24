// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RentCar.Infrastructure.Swagger;

public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1",
            new()
            {
                Title = "Rent Car API",
                Description =
                    "Streamlined car rental management, including reservation, fleet admin, and payment features",
                Contact = new() { Name = "Nhan Nguyen", Email = "nguyenxuannhan407@gmail.com" },
                License = new() { Name = "MIT", Url = new("https://opensource.org/licenses/MIT") }
            });

        options.AddSecurityDefinition("Bearer",
            new()
            {
                Name = "Authorization",
                Description = "Enter the Bearer Authorization string as following: `Generated-JWT-Token`",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

        options.AddSecurityRequirement(new()
        {
            {
                new()
                {
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    In = ParameterLocation.Header,
                    Reference = new()
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme, Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
    }
}
