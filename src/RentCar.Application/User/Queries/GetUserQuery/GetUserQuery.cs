// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.User.Dto;

namespace RentCar.Application.User.Queries.GetUserQuery;

public sealed record GetUserQuery(string Id) : IQuery<Result<UserDto>>;
