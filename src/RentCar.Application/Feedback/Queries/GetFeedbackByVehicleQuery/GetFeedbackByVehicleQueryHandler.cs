// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

using RentCar.Application.Abstraction.Queries.GetEntitiesByFieldQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Feedback.Dto;
using RentCar.Core.Specifications.Feedback;

namespace RentCar.Application.Feedback.Queries.GetFeedbackByVehicleQuery;

public sealed class GetFeedbackByVehicleQueryHandler(IReadRepositoryBase<Core.Entities.Feedback> repository)
    : GetEntitiesByFieldQueryHandler<GetFeedbackByVehicleQuery, Core.Entities.Feedback, FeedbackDto,
        FeedbackByVehicleId>(repository);

public sealed class GetFeedbackByVehicleQueryValidator : PagedValidator<GetFeedbackByVehicleQuery>;
