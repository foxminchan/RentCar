// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using RentCar.Core.Enums;
using RentCar.Core.Interfaces;
using RentCar.Core.ValueObjects;

namespace RentCar.Application.User.Commands.UpdateUserCommand;

public sealed record UpdateUserCommand(
    string Id,
    string? FirstName,
    string? LastName,
    Address? Address,
    string? CardId,
    string? LicenseId,
    LicenseType LicenseType,
    DateOnly DateOfBirth,
    string Email,
    string Password,
    string ConfirmPassword) : ICommand<Result<Unit>>, ITransactionRequest;
