// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;
using RentCar.Core.Enums;
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
    public string? UserId { get; set; }
    [JsonIgnore] public ApplicationUser? User { get; set; }
    public Guid? PaymentId { get; set; }
    [JsonIgnore] public Payment? Payment { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; } = new List<Feedback>();
}
