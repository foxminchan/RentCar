// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.User.Dto;
using RentCar.Core.Identity;
using RentCar.Infrastructure.Abstraction.Validators;

namespace RentCar.Application.User.Queries.GetUsersQuery;

public sealed class GetUsersQueryHandler(UserManager<ApplicationUser> userManager)
    : IQueryHandler<GetUsersQuery, PagedResult<IEnumerable<UserDto>>>
{
    public async Task<PagedResult<IEnumerable<UserDto>>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var query = userManager.Users.OrderBy(x => x.GetType().GetProperty(request.Spec.OrderBy)!.GetValue(x, null));

        if (!request.Spec.IsAscending)
            query = query.OrderDescending();

        var users = await query
            .Skip((int)((request.Spec.PageNumber - 1) * request.Spec.PageSize))
            .Take((int)request.Spec.PageSize)
            .OrderBy(x => x.GetType().GetProperty(request.Spec.OrderBy)!.GetValue(x, null))
            .ProjectToType<UserDto>()
            .ToListAsync(cancellationToken);

        var count = await userManager.Users.CountAsync(cancellationToken);
        var totalPage = (int)Math.Ceiling((double)count / request.Spec.PageSize);
        var pagedInfo = new PagedInfo(
            request.Spec.PageNumber,
            request.Spec.PageSize,
            totalPage,
            count);
        return new(pagedInfo, users);
    }
}

public sealed class GetUsersQueryValidator : PagedValidator<GetUsersQuery>;
