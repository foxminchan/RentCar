// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Enums;

namespace RentCar.Application.Rental.Dto;

public sealed record RentalDto
{
    public Guid Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? TotalPrice { get; set; }
    public RentStatus? Status { get; set; }
    public Guid VehicleId { get; set; }
    public string? UserId { get; set; }
    public Guid? PaymentId { get; set; }
}
