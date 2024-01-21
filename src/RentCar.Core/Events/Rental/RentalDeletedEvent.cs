using RentCar.Core.SharedKernel;

namespace RentCar.Core.Events.Rental;

public sealed class RentalDeletedEvent(Guid id) : BaseEvent
{
    public Guid Id { get; } = id;
}
