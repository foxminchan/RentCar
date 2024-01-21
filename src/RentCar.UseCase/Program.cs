// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using RentCar.Application;
using RentCar.Core.Identity;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.OpenTelemetry;
using RentCar.Infrastructure;
using RentCar.UseCase.Extensions;
using System.IO.Compression;
using System.Net.Mime;

var builder = WebApplication.CreateSlimBuilder(args);

builder.AddOpenTelemetry();

builder.Services.AddRateLimiting();

builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
        options.Providers.Add<GzipCompressionProvider>();
        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
            [MediaTypeNames.Application.Json, MediaTypeNames.Text.Plain, MediaTypeNames.Image.Jpeg]
        );
    })
    .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal)
    .AddResponseCaching(options => options.MaximumBodySize = 1024)
    .AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder);
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

builder.Services.AddApplication();

builder.Services.AddCors(options => options
    .AddDefaultPolicy(
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .MapGroup("/api/auth")
    .MapIdentityApi<ApplicationUser>()
    .WithTags("Auth");

app
    .UseHsts()
    .UseCors()
    .UseDeveloperExceptionPage()
    .UseExceptionHandler()
    .UseHttpsRedirection()
    .UseRateLimiter()
    .UseResponseCaching()
    .UseResponseCompression()
    .UseStatusCodePages();

app.UseWebInfrastructure();

app.MapPrometheusScrapingEndpoint();

app.Run();
