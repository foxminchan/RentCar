// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using RentCar.Core.Identity;

namespace RentCar.Application.User.Commands.DeleteUserCommand;

public sealed class DeleteUserCommandHandler(UserManager<ApplicationUser> userManager) 
    : ICommandHandler<DeleteUserCommand, Result>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, user);
        await userManager.DeleteAsync(user);
        return Result.Success();
    }
}

public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
