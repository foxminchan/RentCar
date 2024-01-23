// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Feedback.Dto;
using RentCar.Core.Specifications.Feedback;

namespace RentCar.Application.Feedback.Queries.GetFeedbackQuery;

public sealed class GetFeedbackQueryHandler(IReadRepositoryBase<Core.Entities.Feedback> repository)
    : GetEntityQueryHandler<GetFeedbackQuery, Core.Entities.Feedback, FeedbackDto, FeedbackById>(repository);
