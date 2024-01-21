using Ardalis.Specification;

namespace RentCar.Core.Specifications.Vehicle;

public sealed class VehicleById : Specification<Entities.Vehicle>
{
    public VehicleById(Ulid id)
    {
        Query.Where(x => x.Id == id);
    }
}
