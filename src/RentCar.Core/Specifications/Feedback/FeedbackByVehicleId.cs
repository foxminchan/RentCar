using Ardalis.Specification;

namespace RentCar.Core.Specifications.Feedback;

public sealed class FeedbackByVehicleId : Specification<Entities.Feedback>
{
    public FeedbackByVehicleId(Guid vehicleId, SpecificationBase spec)
    {
        Query.Take((int)spec.PageSize);
        Query.Skip((int)((spec.PageNumber - 1) * spec.PageSize));
        Query.Where(x => x.Rental!.VehicleId == vehicleId);

        if (spec.IsAscending)
            Query.OrderBy(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
        else
            Query.OrderByDescending(x => x.GetType().GetProperty(spec.OrderBy ?? "Id")!.GetValue(x, null));
    }
}
