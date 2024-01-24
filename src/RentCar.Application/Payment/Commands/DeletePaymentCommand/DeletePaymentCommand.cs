// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;

namespace RentCar.Application.Payment.Commands.DeletePaymentCommand;

public sealed record DeletePaymentCommand(Guid Id) : DeleteEntityCommand(Id);
