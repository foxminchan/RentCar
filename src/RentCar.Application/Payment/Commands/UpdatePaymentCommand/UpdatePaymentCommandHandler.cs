// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Payment.Commands.UpdatePaymentCommand;

public class UpdatePaymentCommandHandler(Repository<Core.Entities.Payment> repository)
    : UpdateEntityCommandHandler<UpdatePaymentCommand, Core.Entities.Payment>(repository);

public sealed class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentCommandValidator(ApplicationDbContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.CardNumber)
            .NotEmpty()
            .WithMessage("Card number is required")
            .CreditCard()
            .WithMessage("Card number is not valid");

        RuleFor(x => x.CardHolderName)
            .NotEmpty()
            .WithMessage("Card holder name is required")
            .MaximumLength(50)
            .WithMessage("Card holder name must not exceed 50 characters");

        RuleFor(x => x.ExpirationDate)
            .NotEmpty()
            .WithMessage("Expiration date is required")
            .GreaterThan(DateTime.Now)
            .WithMessage("Expiration date must be greater than current date");

        RuleFor(x => x.SecurityCode)
            .NotEmpty()
            .WithMessage("Security code is required")
            .Length(3, 3)
            .WithMessage("Security code must be 3 characters");

        RuleFor(x => x)
            .MustAsync(async (command, token) =>
                await context.Payments
                    .FirstOrDefaultAsync(x => x.CardNumber == command.CardNumber, cancellationToken: token) is null
            )
            .WithMessage("Payment with this card number already exists");
    }
}
