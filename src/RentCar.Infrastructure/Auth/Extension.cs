// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Core.Constants;
using RentCar.Core.Identity;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Auth;

public static class Extension
{
    public static void AddApplicationIdentity(this IServiceCollection services)
    {
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

        services.AddAuthorizationBuilder()
            .AddPolicy(Roles.Admin,
                policy => policy
                    .RequireRole(Policies.Admin)
                    .RequireClaim(ClaimTypes.Role, Claims.Create, Claims.Read, Claims.Update, Claims.Delete))
            .AddPolicy(Roles.Customer,
                policy => policy
                    .RequireRole(Policies.Customer)
                    .RequireClaim(ClaimTypes.Role, Claims.Create, Claims.Read));

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
    }

    public static void MapIdentity(this WebApplication app)
    {
        app.UseAuthentication().UseAuthorization();
        app
            .MapGroup("/api/auth")
            .MapIdentityApi<ApplicationUser>()
            .WithTags("Auth");
    }
}
