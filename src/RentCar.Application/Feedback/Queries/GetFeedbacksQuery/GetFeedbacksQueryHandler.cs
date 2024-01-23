// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;
using RentCar.Application.Feedback.Dto;
using RentCar.Core.Specifications.Feedback;
using RentCar.Infrastructure.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Infrastructure.Abstraction.Validators;

namespace RentCar.Application.Feedback.Queries.GetFeedbacksQuery;

public sealed class GetFeedbacksQueryHandler(IReadRepositoryBase<Core.Entities.Feedback> repository)
    : GetEntitiesQueryHandler<GetFeedbacksQuery, Core.Entities.Feedback, FeedbackDto, FeedbackFilterPaginated>(repository);

public sealed class GetFeedbacksQueryValidator : PagedValidator<FeedbackDto>;
