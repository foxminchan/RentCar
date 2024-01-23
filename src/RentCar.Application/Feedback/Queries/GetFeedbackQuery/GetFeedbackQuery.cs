// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Feedback.Dto;
using RentCar.Infrastructure.Abstraction.Queries.GetEntityQuery;

namespace RentCar.Application.Feedback.Queries.GetFeedbackQuery;

public sealed record GetFeedbackQuery(Guid Id) : GetEntityQuery<FeedbackDto>(Id);
