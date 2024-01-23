// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.User.Dto;

namespace RentCar.Application.User.Queries.GetUserQuery;

public sealed record GetUserQuery(Guid Id) : GetEntityQuery<UserDto>(Id);
