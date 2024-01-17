// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SmartEnum;

namespace RentCar.Core.Enums;

public sealed class CarStatus(string name, int value) : SmartEnum<CarStatus>(name, value)
{
    public static readonly CarStatus Available = new(nameof(Available), 1);
    public static readonly CarStatus Rented = new(nameof(Rented), 2);
    public static readonly CarStatus Repairing = new(nameof(Repairing), 3);
    public static readonly CarStatus Lost = new(nameof(Lost), 4);
    public static readonly CarStatus Unknown = new(nameof(Unknown), 5);
}
