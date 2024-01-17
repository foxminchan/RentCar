// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Identity;

using RentCar.Core.Enums;
using RentCar.Core.ValueObjects;

namespace RentCar.Core.Identity;

public class ApplicationUser : IdentityUser
{
    [PersonalData] public virtual string? FirstName { get; set; }
    [PersonalData] public virtual string? LastName { get; set; }
    [PersonalData] public virtual Address? Address { get; set; }
    [PersonalData] public virtual string? CardId { get; set; }
    [PersonalData] public virtual string? LicenseId { get; set; }
    [PersonalData] public virtual LicenseType LicenseType { get; set; } = LicenseType.A1;
    [PersonalData] public virtual DateOnly DateOfBirth { get; set; }
}
