using Ardalis.SharedKernel;

namespace RentCar.Core.Events.Rental;

public sealed class RentalDeletedEvent(Guid id) : DomainEventBase
{
    public Guid Id { get; } = id;
}
