// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Abstraction.Validators;

public class IdValidator<TModel> : AbstractValidator<Guid?>
    where TModel : class
{
    private readonly ApplicationDbContext _context;

    public IdValidator(ApplicationDbContext context, string query)
    {
        _context = context;
        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage($"{typeof(TModel).Name}Id is required")
            .MustAsync((id, cancellation) => ValidateId(id, cancellation, query))
            .WithMessage($"{typeof(TModel).Name}Id is not valid");
    }

    private async Task<bool> ValidateId(Guid? id, CancellationToken cancellation, string query)
        => id is { } && await _context.Set<TModel>()
            .FromSqlRaw(query, id)
            .AnyAsync(cancellation);
}
