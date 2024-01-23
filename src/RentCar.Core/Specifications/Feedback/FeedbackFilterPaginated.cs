// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Feedback;

public sealed class FeedbackFilterPaginated : Specification<Entities.Feedback>
{
    public FeedbackFilterPaginated(long pageNumber, long pageSize, string orderBy, bool isDescending)
    {
        Query.Take((int)pageSize);
        Query.Skip((int)((pageNumber - 1) * pageSize));

        if (isDescending)
            Query.OrderByDescending(x => x.GetType().GetProperty(orderBy)!.GetValue(x, null));
        else
            Query.OrderBy(x => x.GetType().GetProperty(orderBy)!.GetValue(x, null));
    }
}
