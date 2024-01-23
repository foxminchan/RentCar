// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Enums;
using RentCar.Infrastructure.Abstraction.Commands.UpdateEntityCommand;

namespace RentCar.Application.Rental.Commands.UpdateRentalCommand;

public sealed record UpdateRentalCommand(
    Guid Id,
    DateTime? StartDate,
    DateTime? EndDate,
    decimal? TotalPrice,
    RentStatus? Status,
    Guid? VehicleId,
    Guid? UserId,
    Guid? PaymentId) : UpdateEntityCommand;
