// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Vehicle.Validators;

public sealed class VehicleIdValidator : AbstractValidator<Guid>
{
    private readonly ApplicationDbContext _context;

    public VehicleIdValidator(ApplicationDbContext context)
    {
        _context = context;
        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("VehicleId is required")
            .MustAsync(ValidateId)
            .WithMessage("VehicleId is not valid");
    }

    private async Task<bool> ValidateId(Guid id, CancellationToken cancellationToken)
        => await _context.Vehicles
            .FromSqlRaw("SELECT Id FROM Vehicle WHERE Id = {0}", id)
            .AnyAsync(cancellationToken);
}
