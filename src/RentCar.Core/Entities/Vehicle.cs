using RentCar.Core.Enums;
using RentCar.Core.Interfaces;
using RentCar.Core.SharedKernel;

namespace RentCar.Core.Entities;

public sealed class Vehicle : BaseEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public string? Plate { get; set; }
    public VehicleType? Type { get; set; }
    public string? Image { get; set; }
}
