// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;
using FluentValidation;

using RentCar.Application.Abstraction.Commands.CreateEntityCommand;
using RentCar.Application.Rental.Validators;

namespace RentCar.Application.Feedback.Commands.CreateFeedbackCommand;

public sealed class CreateFeedbackCommandHandler(IRepositoryBase<Core.Entities.Feedback> repository)
    : CreateEntityCommandHandler<CreateFeedbackCommand, Core.Entities.Feedback>(repository);

public sealed class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
{
    public CreateFeedbackCommandValidator(RentalIdValidator rentalIdValidator)
    {
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
