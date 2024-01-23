// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;

namespace RentCar.Application.Rental.Commands.DeleteRentalCommand;

public sealed record DeleteRentalCommand(Guid Id) : DeleteEntityCommand(Id);
