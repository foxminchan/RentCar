// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RentCar.Infrastructure.Filters;

public sealed class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
            return;

        schema.Enum.Clear();
        schema.Type = "string";
        Enum.GetNames(context.Type)
            .ToList()
            .ForEach(name => schema.Enum.Add(new OpenApiString($"{name}")));
    }
}
