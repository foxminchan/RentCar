// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Feedback.Dto;
using RentCar.Core.Specifications.Feedback;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Feedback.Queries.GetFeedbackQuery;

public sealed class GetFeedbackQueryHandler(Repository<Core.Entities.Feedback> repository)
    : GetEntityQueryHandler<GetFeedbackQuery, Core.Entities.Feedback, FeedbackDto, FeedbackById>(repository);
