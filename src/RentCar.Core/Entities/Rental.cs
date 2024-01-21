// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Text.Json.Serialization;
using RentCar.Core.Enums;
using RentCar.Core.Identity;
using RentCar.Core.Interfaces;
using RentCar.Core.SharedKernel;

namespace RentCar.Core.Entities;

public sealed class Rental : BaseEntity, IAggregateRoot
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? TotalPrice { get; set; }
    public RentStatus? Status { get; set; } = RentStatus.Renting;
    public Ulid? VehicleId { get; set; }
    [JsonIgnore] public Vehicle? Vehicle { get; set; }
    public string? UserId { get; set; }
    [JsonIgnore] public ApplicationUser? User { get; set; }
    public Ulid? PaymentId { get; set; }
    [JsonIgnore] public Payment? Payment { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; } = new List<Feedback>();
}
