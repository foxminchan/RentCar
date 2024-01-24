// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using RentCar.Core.Events.Maintenance;
using System.Text.Json.Serialization;

namespace RentCar.Core.Entities;

public sealed class Maintenance : EntityBase<Guid>, IAggregateRoot
{
    public DateTime? Date { get; set; } = DateTime.UtcNow;
    public string? Description { get; set; }
    public decimal? Cost { get; set; }
    public Guid VehicleId { get; set; }
    [JsonIgnore] public Vehicle? Vehicle { get; set; }

    public void AddMaintenance(Guid vehicleId)
    {
        Guard.Against.NullOrEmpty(vehicleId);
        var @event = new MaintenanceCreatedEvent(vehicleId);
        RegisterDomainEvent(@event);
    }
}
