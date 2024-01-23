// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.User.Dto;
using RentCar.Infrastructure.Abstraction.Queries.GetEntityQuery;

namespace RentCar.Application.User.Queries.GetUserQuery;

public sealed record GetUserQuery(Guid Id) : GetEntityQuery<UserDto>(Id);
