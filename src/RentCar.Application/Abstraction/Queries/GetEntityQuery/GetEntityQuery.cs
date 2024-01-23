// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;

namespace RentCar.Application.Abstraction.Queries.GetEntityQuery;

public record GetEntityQuery<T>(Guid Id) : IQuery<Result<T>> where T : notnull;
