// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using RentCar.Core.Enums;

namespace RentCar.Application.Rental.Commands.UpdateRentalCommand;

public sealed record UpdateRentalCommand(
    Guid Id,
    DateTime? StartDate,
    DateTime? EndDate,
    decimal? TotalPrice,
    RentStatus? Status,
    Guid VehicleId,
    string? UserId,
    Guid? PaymentId) : ICommand<Result<Unit>>;
