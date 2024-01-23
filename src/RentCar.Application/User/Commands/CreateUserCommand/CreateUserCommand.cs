// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Enums;
using RentCar.Core.ValueObjects;
using RentCar.Infrastructure.Abstraction.Commands.CreateEntityCommand;

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
