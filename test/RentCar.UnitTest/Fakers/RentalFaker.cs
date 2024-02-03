using Bogus;

namespace RentCar.Unit.Test.Fakers;

public sealed class RentalFaker : Faker<Core.Entities.Rental>
{
    public RentalFaker()
    {
        RuleFor(x => x.Id, f => f.Random.Guid());
        RuleFor(x => x.UserId, f => f.Random.Guid());
        RuleFor(x => x.VehicleId, f => f.Random.Guid());
        RuleFor(x => x.StartDate, f => f.Date.Past());
        RuleFor(x => x.EndDate, f => f.Date.Future());
        RuleFor(x => x.Status, f => f.PickRandom<Core.Enums.RentStatus>());
        RuleFor(x => x.TotalPrice, f => f.Random.Decimal());
    }
}
