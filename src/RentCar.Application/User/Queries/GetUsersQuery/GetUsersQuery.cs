﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.User.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.User.Queries.GetUsersQuery;

public sealed record GetUsersQuery(SpecificationBase Spec) : GetEntitiesQuery<UserDto>(Spec);
