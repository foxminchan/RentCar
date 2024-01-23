// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Infrastructure.Abstraction.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Rental.Validators;

public sealed class RentalIdValidator(ApplicationDbContext context) 
    : IdValidator<Core.Entities.Rental>(context, "SELECT Id FROM Rentals WHERE Id = {0}");
