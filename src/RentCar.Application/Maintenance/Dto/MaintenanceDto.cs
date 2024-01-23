// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

namespace RentCar.Application.Maintenance.Dto;

public sealed record MaintenanceDto
{
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public decimal? Cost { get; set; }
    public Guid VehicleId { get; set; }
}
