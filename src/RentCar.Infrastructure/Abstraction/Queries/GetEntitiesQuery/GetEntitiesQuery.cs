// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Core.Specifications;

namespace RentCar.Infrastructure.Abstraction.Queries.GetEntitiesQuery;

public record GetEntitiesQuery<T>(SpecificationBase Spec) : IQuery<PagedResult<IEnumerable<T>>> where T : notnull;
