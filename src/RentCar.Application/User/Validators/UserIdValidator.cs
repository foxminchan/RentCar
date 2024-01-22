// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.User.Validators;

public class UserIdValidator : AbstractValidator<string>
{
    private readonly ApplicationDbContext _context;

    public UserIdValidator(ApplicationDbContext context)
    {
        _context = context;
        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("UserId is required")
            .MustAsync(ValidateId)
            .WithMessage("UserId is not valid");
    }

    private async Task<bool> ValidateId(string id, CancellationToken cancellationToken)
        => await _context.Vehicles
            .FromSqlRaw("SELECT Id FROM AspNetUsers WHERE Id = {0}", id)
            .AnyAsync(cancellationToken);
}
