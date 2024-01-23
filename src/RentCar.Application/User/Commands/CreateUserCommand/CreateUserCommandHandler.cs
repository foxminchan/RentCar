// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Identity;
using RentCar.Application.User.Validators;
using RentCar.Core.Constants;
using RentCar.Core.Identity;
using System.Security.Claims;

namespace RentCar.Application.User.Commands.CreateUserCommand;

public sealed class CreateUserCommandHandler(UserManager<ApplicationUser> userManager)
    : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<ApplicationUser>();

        if (userManager.Users.Any(u => u.UserName == request.Email))
            return Result.Invalid(new ValidationError("Email already exists"));

        if (userManager.Users.Any(u => u.Email == request.Email))
            return Result.Invalid(new ValidationError("Email already exists"));

        var user = new ApplicationUser
        {
            UserName = entity.Email,
            Email = entity.Email,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Address = entity.Address,
            CardId = entity.CardId,
            LicenseId = entity.LicenseId,
            LicenseType = entity.LicenseType,
            DateOfBirth = entity.DateOfBirth
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return Result.Invalid(new List<ValidationError>(
                result.Errors.Select(e => new ValidationError(e.Description))));

        await userManager.AddToRoleAsync(user, Roles.Customer);
        await userManager.AddClaimAsync(user, new(ClaimTypes.Role, Policies.Create));
        await userManager.AddClaimAsync(user, new(ClaimTypes.Role, Policies.Read));

        return Result.Success(user.Id);
    }
}

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is required")
            .MaximumLength(50)
            .WithMessage("First Name must not exceed 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last Name is required")
            .MaximumLength(20)
            .WithMessage("Last Name must not exceed 20 characters");

        RuleFor(x => x.Address)
            .SetValidator(new AddressValidator()!);

        RuleFor(x => x.CardId)
            .NotEmpty()
            .WithMessage("Card Id is required")
            .MaximumLength(12)
            .WithMessage("Card Id must not exceed 12 characters");

        RuleFor(x => x.LicenseId)
            .NotEmpty()
            .WithMessage("License Id is required")
            .MaximumLength(12)
            .WithMessage("License Id must not exceed 12 characters");

        RuleFor(x => x.LicenseType)
            .IsInEnum()
            .WithMessage("License Type is required");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateOnly.FromDateTime(DateTime.Now.AddYears(-18)))
            .WithMessage("You must be 18 years old");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is invalid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")
            .WithMessage(
                "Password must be between 8 and 15 characters and contain at least one uppercase letter, one lowercase letter, and one number");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password)
            .WithMessage("Password and Confirm Password must be the same");
    }
}
