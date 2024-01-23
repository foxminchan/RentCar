using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;

namespace RentCar.Application.Maintenance.Commands.UpdateMaintenanceCommand;

public sealed record UpdateMaintenanceCommand(
    Guid Id,
    DateTime? Date,
    string? Description,
    decimal? Cost,
    Guid? VehicleId) : UpdateEntityCommand;
