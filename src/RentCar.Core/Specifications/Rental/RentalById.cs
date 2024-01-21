using Ardalis.Specification;

namespace RentCar.Core.Specifications.Rental;

public sealed class RentalById : Specification<Entities.Rental>
{
    public RentalById(Ulid id)
    {
        Query.Where(x => x.Id == id);
    }
}
