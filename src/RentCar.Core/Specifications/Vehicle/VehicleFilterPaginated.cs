using Ardalis.Specification;

namespace RentCar.Core.Specifications.Vehicle;

public sealed class VehicleFilterPaginated : Specification<Entities.Vehicle>
{
    public VehicleFilterPaginated(int skip, int take)
    {
        Query.Skip(skip);
        Query.Take(take);
    }
}
