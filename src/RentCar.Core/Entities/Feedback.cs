﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Text.Json.Serialization;
using Ardalis.SharedKernel;

namespace RentCar.Core.Entities;

public sealed class Feedback : EntityBase<Guid>
{
    public string? Message { get; set; }
    public byte? Rating { get; set; }
    public bool? IsApproved { get; set; }
    public Guid? RentalId { get; set; }
    [JsonIgnore] public Rental? Rental { get; set; }
}
