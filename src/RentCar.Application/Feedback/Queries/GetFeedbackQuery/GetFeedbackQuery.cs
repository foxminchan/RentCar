// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Feedback.Dto;

namespace RentCar.Application.Feedback.Queries.GetFeedbackQuery;

public sealed record GetFeedbackQuery(Guid Id) : GetEntityQuery<FeedbackDto>(Id);
