// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Enums;
using RentCar.Infrastructure.Abstraction.Commands.CreateEntityCommand;

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
