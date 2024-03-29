﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Builder;
using Serilog.Exceptions;
using Serilog.Settings.Configuration;
using Serilog.Sinks.SystemConsole.Themes;
using Serilog;

namespace RentCar.Infrastructure.Logging;

public static class Extension
{
    public static void AddSerilog(this WebApplicationBuilder builder, string sectionName = "Serilog")
    {
        builder.Host.UseSerilog((context, config) =>
        {
            config.ReadFrom.Configuration(
                context.Configuration,
                new ConfigurationReaderOptions { SectionName = sectionName }
            );

            config
                .Enrich.WithProperty("Application", builder.Environment.ApplicationName)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails();

            config.WriteTo.Async(writeTo =>
                writeTo.Console(
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level} - {Message:lj}{NewLine}{Exception}",
                    theme: AnsiConsoleTheme.Literate));
        });
    }
}
