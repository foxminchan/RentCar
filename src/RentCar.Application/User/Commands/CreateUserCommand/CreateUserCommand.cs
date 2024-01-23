// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.CreateEntityCommand;
using RentCar.Core.Enums;
using RentCar.Core.ValueObjects;

namespace RentCar.Application.User.Commands.CreateUserCommand;

public sealed record CreateUserCommand(
    string? FirstName,
    string? LastName,
    Address? Address,
    string? CardId,
    string? LicenseId,
    LicenseType LicenseType,
    DateOnly DateOfBirth,
    string Email,
    string Password,
    string ConfirmPassword) : CreateEntityCommand;
