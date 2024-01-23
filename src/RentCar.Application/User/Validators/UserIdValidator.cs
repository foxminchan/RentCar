// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Core.Identity;
using RentCar.Infrastructure.Abstraction.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.User.Validators;

public sealed class UserIdValidator(ApplicationDbContext context) 
    : IdValidator<ApplicationUser>(context, "SELECT Id FROM AspNetUsers WHERE Id = {0}");
