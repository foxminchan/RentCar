// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;

namespace RentCar.Application.Payment.Commands.UpdatePaymentCommand;

public sealed record UpdatePaymentCommand(
    Guid Id,
    string? CardNumber,
    string? CardHolderName,
    DateTime? ExpirationDate,
    string? SecurityCode) : UpdateEntityCommand;
