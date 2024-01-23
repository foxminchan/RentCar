// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Feedback.Dto;
using RentCar.Core.Specifications;
using RentCar.Infrastructure.Abstraction.Queries.GetEntitiesQuery;

namespace RentCar.Application.Feedback.Queries.GetFeedbacksQuery;

public sealed record GetFeedbacksQuery(SpecificationBase Spec) : GetEntitiesQuery<FeedbackDto>(Spec);
