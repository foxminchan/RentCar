// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using RentCar.Core.Specifications;

namespace RentCar.Infrastructure.Abstraction.Validators;

public class PagedValidator<TModel> : AbstractValidator<SpecificationBase> where TModel : notnull
{
    public PagedValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage("PageSize must be greater than 0");

        RuleFor(x => x.OrderBy)
            .Must(x => typeof(TModel).GetProperties().Any(p => p.Name == x))
            .WithMessage("There is no such property to order");
    }
}
