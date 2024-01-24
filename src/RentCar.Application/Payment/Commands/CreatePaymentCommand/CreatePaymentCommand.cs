// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.CreateEntityCommand;

namespace RentCar.Application.Payment.Commands.CreatePaymentCommand;

public sealed record CreatePaymentCommand(
    string? CardNumber,
    string? CardHolderName,
    DateTime? ExpirationDate,
    string? SecurityCode) : CreateEntityCommand;
