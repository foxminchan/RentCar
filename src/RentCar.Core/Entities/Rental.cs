// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using RentCar.Core.Enums;
using RentCar.Core.Events.Rental;
using RentCar.Core.Identity;
using System.Text.Json.Serialization;

namespace RentCar.Core.Entities;

public sealed class Rental : EntityBase<Guid>, IAggregateRoot
{
    public DateTime? StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    public decimal? TotalPrice { get; set; }
    public RentStatus? Status { get; set; } = RentStatus.Renting;
    public Guid VehicleId { get; set; }
    [JsonIgnore] public Vehicle? Vehicle { get; set; }
    public Guid? UserId { get; set; }
    [JsonIgnore] public ApplicationUser? User { get; set; }
    public Guid? PaymentId { get; set; }
    [JsonIgnore] public Payment? Payment { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; } = new List<Feedback>();

    public void AddRental(Guid vehicleId)
    {
        Guard.Against.NullOrEmpty(vehicleId, nameof(vehicleId));
        var @event = new RentalCreatedEvent(vehicleId);
        RegisterDomainEvent(@event);
    }

    public void DeleteRental(Guid vehicleId, Guid rentalId, DateTime? endDate)
    {
        Guard.Against.NullOrEmpty(vehicleId, nameof(vehicleId));
        Guard.Against.NullOrEmpty(rentalId, nameof(rentalId));
        Guard.Against.Null(endDate, nameof(endDate));
        var @event = new RentalDeletedEvent(vehicleId, rentalId, endDate);
        RegisterDomainEvent(@event);
    }

    public void UpdateRental(Guid vehicleId, Guid rentalId, RentStatus? status)
    {
        Guard.Against.NullOrEmpty(vehicleId, nameof(vehicleId));
        Guard.Against.NullOrEmpty(rentalId, nameof(rentalId));
        Guard.Against.Null(status, nameof(status));
        var @event = new RentalUpdatedEvent(vehicleId, rentalId, status);
        RegisterDomainEvent(@event);
    }
}
