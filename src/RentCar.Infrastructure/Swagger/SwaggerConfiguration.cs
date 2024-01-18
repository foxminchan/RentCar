// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace RentCar.Infrastructure.Swagger;

public static class SwaggerConfiguration
{
    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app)
    {
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "swagger/{documentName}/swagger.json";
            c.PreSerializeFilters.Add((swagger, httpReq) =>
            {
                ArgumentNullException.ThrowIfNull(httpReq, nameof(httpReq));

                swagger.Servers = new List<OpenApiServer>
                {
                    new()
                    {
                        Url = $"{httpReq.Scheme}://{httpReq.Host.Value}",
                        Description = string.Join(" ",
                            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production,
                            "Environment")
                    }
                };
            });
        });

        app.UseSwaggerUI(c =>
        {
            c.DocumentTitle = "Rent Car API";
            foreach (var description in app.ApplicationServices
                         .GetRequiredService<IApiVersionDescriptionProvider>()
                         .ApiVersionDescriptions)
                c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            c.DisplayRequestDuration();
            c.EnableFilter();
            c.EnableValidator();
            c.EnableTryItOutByDefault();
            c.EnablePersistAuthorization();
        });

        return app;
    }
}
