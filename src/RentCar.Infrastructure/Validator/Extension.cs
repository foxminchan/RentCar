// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace RentCar.Infrastructure.Validator;

public static class Extension
{
    public static OptionsBuilder<TOption> ValidateFluentValidation<TOption>(
        this OptionsBuilder<TOption> builder)
        where TOption : class
    {
        builder.Services.AddSingleton<IValidateOptions<TOption>>(service =>
            new OptionValidation<TOption>(service));
        return builder;
    }
}
