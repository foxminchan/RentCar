using RentCar.Core.SharedKernel;

namespace RentCar.Core.Events.Rental;

public sealed class RentalDeletedEvent(Ulid id) : BaseEvent
{
    public Ulid Id { get; } = id;
}
