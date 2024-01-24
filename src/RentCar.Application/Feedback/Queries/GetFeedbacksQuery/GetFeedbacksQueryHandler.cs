// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Feedback.Dto;
using RentCar.Core.Specifications.Feedback;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Feedback.Queries.GetFeedbacksQuery;

public sealed class GetFeedbacksQueryHandler(Repository<Core.Entities.Feedback> repository)
    : GetEntitiesQueryHandler<GetFeedbacksQuery, Core.Entities.Feedback, FeedbackDto, FeedbackFilterPaginated>(repository);

public sealed class GetFeedbacksQueryValidator : PagedValidator<FeedbackDto>;
