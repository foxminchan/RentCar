using Ardalis.SharedKernel;

namespace RentCar.Core.Events.Maintenance;

public sealed class MaintenanceCreatedEvent(Guid vehicleId) : DomainEventBase
{
    public Guid VehicleId { get; set; } = vehicleId;
}
