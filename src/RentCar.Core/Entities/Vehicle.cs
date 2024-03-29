﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;
using RentCar.Core.Enums;

namespace RentCar.Core.Entities;

public sealed class Vehicle : EntityBase<Guid>
{
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public string? Plate { get; set; }
    public VehicleType? Type { get; set; } = VehicleType.Sedan;
    public CarStatus? Status { get; set; } = CarStatus.Available;
    public string? Image { get; set; }
    public ICollection<Rental>? Rentals { get; set; } = new List<Rental>();
    public ICollection<Maintenance>? Maintenances { get; set; } = new List<Maintenance>();
}
