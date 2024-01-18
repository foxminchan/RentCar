using RentCar.Core.SharedKernel;

namespace RentCar.Core.Events.Rental;

public class RentalCompleteEvent(Entities.Rental rental) : BaseEvent
{
    public Entities.Rental Rental { get; } = rental;
}
