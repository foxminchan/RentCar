// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SmartEnum;

namespace RentCar.Core.Constant;

public sealed class LicenseType(string name, int value) : SmartEnum<LicenseType>(name, value)
{
    public static readonly LicenseType A1 = new(nameof(A1), 1);
    public static readonly LicenseType A2 = new(nameof(A2), 2);
    public static readonly LicenseType A3 = new(nameof(A3), 3);
    public static readonly LicenseType A4 = new(nameof(A4), 4);
    public static readonly LicenseType B1 = new(nameof(B1), 5);
    public static readonly LicenseType B2 = new(nameof(B2), 6);
    public static readonly LicenseType C = new(nameof(C), 7);
    public static readonly LicenseType D = new(nameof(D), 8);
    public static readonly LicenseType E = new(nameof(E), 9);
    public static readonly LicenseType F = new(nameof(F), 10);
}
