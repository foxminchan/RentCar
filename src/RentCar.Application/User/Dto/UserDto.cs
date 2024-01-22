// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Enums;
using RentCar.Core.ValueObjects;

namespace RentCar.Application.User.Dto;

public sealed record UserDto
{
    public string? Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Address? Address { get; set; }
    public string? CardId { get; set; }
    public string? LicenseId { get; set; }
    public LicenseType LicenseType { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
