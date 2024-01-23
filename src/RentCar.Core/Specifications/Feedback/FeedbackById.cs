// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Feedback;

public sealed class FeedbackById : Specification<Entities.Feedback>
{
    public FeedbackById(Guid id)
    {
        Query.Where(x => x.Id == id);
    }
}
