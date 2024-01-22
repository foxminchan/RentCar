// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace RentCar.Infrastructure.Validator;

public static class Extension
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(
        this OptionsBuilder<TOptions> builder)
        where TOptions : class
    {
        builder.Services.AddSingleton<IValidateOptions<TOptions>>(service =>
            new OptionValidation<TOptions>(service));
        return builder;
    }
}
