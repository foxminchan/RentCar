// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();

