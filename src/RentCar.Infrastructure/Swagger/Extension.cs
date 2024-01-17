using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace RentCar.Infrastructure.Swagger;

public static class Extension
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services)
        => services.AddTransient<IConfigureOptions<SwaggerGenOptions>>()
            .AddFluentValidationRulesToSwagger()
            .AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>())
            .Configure<SwaggerGeneratorOptions>(o => o.InferSecuritySchemes = false);
}
