// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Core.Specifications;

namespace RentCar.Application.Abstraction.Queries.GetEntitiesByFieldQuery;

public record GetEntitiesByFieldQuery<T>(Guid Id, SpecificationBase Spec)
    : IQuery<PagedResult<IEnumerable<T>>> where T : notnull;
