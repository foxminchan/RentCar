// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Mapster;
using Microsoft.AspNetCore.Identity;
using RentCar.Application.User.Dto;
using RentCar.Core.Identity;

namespace RentCar.Application.User.Queries.GetUserQuery;

public sealed class GetUserQueryHandler(UserManager<ApplicationUser> userManager)
    : IQueryHandler<GetUserQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        Guard.Against.NullOrEmpty(request.Id, nameof(request));
        var user = await userManager.FindByIdAsync(request.Id.ToString());
        Guard.Against.NotFound(request.Id, user);
        return Result<UserDto>.Success(user.Adapt<UserDto>());
    }
}
