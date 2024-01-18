// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.UseCase.Extensions;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddRateLimiting();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();

