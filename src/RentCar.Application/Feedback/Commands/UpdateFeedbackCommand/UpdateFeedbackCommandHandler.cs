// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentValidation;
using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;
using RentCar.Application.Rental.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Feedback.Commands.UpdateFeedbackCommand;

public sealed class UpdateFeedbackCommandHandler(Repository<Core.Entities.Feedback> repository)
    : UpdateEntityCommandHandler<UpdateEntityCommand, Core.Entities.Feedback>(repository);

public sealed class UpdateFeedbackCommandValidator : AbstractValidator<UpdateFeedbackCommand>
{
    public UpdateFeedbackCommandValidator(RentalIdValidator rentalIdValidator)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Message is required")
            .MaximumLength(255)
            .WithMessage("Message must not exceed 255 characters");

        RuleFor(x => x.Rating)
            .GreaterThan((byte)0)
            .WithMessage("Rating must be greater than 0")
            .LessThanOrEqualTo((byte)5)
            .WithMessage("Rating must be less than or equal to 5");

        RuleFor(x => x.RentalId)
            .SetValidator(rentalIdValidator);
    }
}
