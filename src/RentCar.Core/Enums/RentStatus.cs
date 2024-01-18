// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SmartEnum;

namespace RentCar.Core.Enums;

public class RentStatus(string name, int value) : SmartEnum<RentStatus>(name, value)
{
    public static readonly RentStatus Renting = new(nameof(Renting), 1);
    public static readonly RentStatus Returned = new(nameof(Returned), 2);
    public static readonly RentStatus Cancelled = new(nameof(Cancelled), 3);
    public static readonly RentStatus Unknown = new(nameof(Unknown), 4);
}
