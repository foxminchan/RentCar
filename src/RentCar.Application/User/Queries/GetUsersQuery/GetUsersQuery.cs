// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.User.Dto;

namespace RentCar.Application.User.Queries.GetUsersQuery;

public sealed record GetUsersQuery(int Skip, int Take) : IQuery<Result<IEnumerable<UserDto>>>;
