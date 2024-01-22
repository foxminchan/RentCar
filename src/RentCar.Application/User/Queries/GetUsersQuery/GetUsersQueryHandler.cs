// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.User.Dto;
using RentCar.Core.Identity;

namespace RentCar.Application.User.Queries.GetUsersQuery;

public sealed class GetUsersQueryHandler(UserManager<ApplicationUser> userManager)
    : IQueryHandler<GetUsersQuery, Result<IEnumerable<UserDto>>>
{
    public async Task<Result<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
        return Result<IEnumerable<UserDto>>.Success(users.Adapt<IEnumerable<UserDto>>());
    }
}
