// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Enums;

namespace RentCar.Application.Vehicle.Dto;

public sealed record VehicleDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public string? Plate { get; set; }
    public VehicleType? Type { get; set; }
    public CarStatus? Status { get; set; }
    public string? Image { get; set; }
}
