// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Core.Identity;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Auth;

public static class Extension
{
    public static void AddApplicationIdentity(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddBearerToken();
        services.AddAuthorizationBuilder();
        services.AddIdentityCore<ApplicationUser>()
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
