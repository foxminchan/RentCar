﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesByFieldQuery;
using RentCar.Application.Feedback.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.Feedback.Queries.GetFeedbackByVehicleQuery;

public sealed record GetFeedbackByVehicleQuery(
    Guid VehicleId,
    SpecificationBase Spec) : GetEntitiesByFieldQuery<FeedbackDto>(VehicleId, Spec);
