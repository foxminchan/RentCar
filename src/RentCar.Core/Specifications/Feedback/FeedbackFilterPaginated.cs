// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Feedback;

public sealed class FeedbackFilterPaginated : Specification<Entities.Feedback>
{
    public FeedbackFilterPaginated(SpecificationBase spec)
    {
        Query.Take((int)spec.PageSize);
        Query.Skip((int)((spec.PageNumber - 1) * spec.PageSize));

        if (spec.IsAscending)
            Query.OrderBy(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
        else
            Query.OrderByDescending(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
    }
}
