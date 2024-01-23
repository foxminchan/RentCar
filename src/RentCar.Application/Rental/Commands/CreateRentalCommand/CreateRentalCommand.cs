// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.CreateEntityCommand;
using RentCar.Core.Enums;

namespace RentCar.Application.Rental.Commands.CreateRentalCommand;

public sealed record CreateRentalCommand(
    DateTime? StartDate,
    DateTime? EndDate,
    decimal? TotalPrice,
    RentStatus? Status,
    Guid? VehicleId,
    Guid? UserId,
    Guid? PaymentId
) : CreateEntityCommand;
