using Ardalis.Specification;

namespace RentCar.Core.Specifications.Feedback;

public sealed class FeedbackByVehicleId : Specification<Entities.Feedback>
{
    public FeedbackByVehicleId(Guid vehicleId, long pageNumber, long pageSize, string orderBy, bool isDescending)
    {
        Query.Take((int)pageSize);
        Query.Skip((int)((pageNumber - 1) * pageSize));
        Query.Where(x => x.Rental!.VehicleId == vehicleId);

        if (isDescending)
            Query.OrderByDescending(x => x.GetType().GetProperty(orderBy)!.GetValue(x, null));
        else
            Query.OrderBy(x => x.GetType().GetProperty(orderBy)!.GetValue(x, null));
    }
}
