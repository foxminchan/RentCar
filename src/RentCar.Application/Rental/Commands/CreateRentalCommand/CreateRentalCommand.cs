// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Core.Enums;
using RentCar.Core.Interfaces;

namespace RentCar.Application.Rental.Commands.CreateRentalCommand;

public record CreateRentalCommand(
    DateTime? StartDate,
    DateTime? EndDate,
    decimal? TotalPrice,
    RentStatus? Status,
    Guid? VehicleId,
    string? UserId,
    Guid? PaymentId
) : ICommand<Result<Guid>>, ITransactionRequest;
