// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Vehicle.Validators;

public sealed class VehicleIdValidator(ApplicationDbContext context)
    : IdValidator<Core.Entities.Vehicle>(context, "SELECT Id FROM Vehicles WHERE Id = {0}");
