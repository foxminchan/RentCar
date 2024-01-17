// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SmartEnum;

namespace RentCar.Core.Enums;

public sealed class VehicleType(string name, int value) : SmartEnum<VehicleType>(name, value)
{
    public static readonly VehicleType Sedan = new(nameof(Sedan), 1);
    public static readonly VehicleType Hatchback = new(nameof(Hatchback), 2);
    public static readonly VehicleType Suv = new(nameof(Suv), 3);
    public static readonly VehicleType Mpv = new(nameof(Mpv), 4);
    public static readonly VehicleType Coupe = new(nameof(Coupe), 5);
    public static readonly VehicleType Convertible = new(nameof(Convertible), 6);
}
