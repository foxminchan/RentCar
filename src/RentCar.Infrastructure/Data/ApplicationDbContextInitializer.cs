// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentCar.Core.Constants;
using RentCar.Core.Identity;

namespace RentCar.Infrastructure.Data;

public sealed class ApplicationDbContextInitializer(
    DbContext context,
    ILogger<ApplicationDbContextInitializer> logger,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
{
    public async Task InitialiseAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Migration error");
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Seeding error");
        }
    }

    public async Task TrySeedAsync()
    {
        if (userManager.Users.Any() || roleManager.Roles.Any())
            return;

        var example = new ApplicationUser
        {
            UserName = "nhan@gmail.com",
            FirstName = "Nguyễn Xuân",
            LastName = "Nhân",
            CardId = "123456789",
            LicenseId = "123456789",
            PhoneNumber = "0123456789",
            DateOfBirth = new(2002, 08, 02),
            Email = "nhan@gmail.com"
        };

        const string password = "P@ssw0rd";

        var result = await userManager.CreateAsync(example, password);

        if (!result.Succeeded)
            throw new(string.Join("\n", result.Errors));

        var admin = new IdentityRole(Roles.Admin);
        var customer = new IdentityRole(Roles.Customer);

        await roleManager.CreateAsync(admin);
        await roleManager.CreateAsync(customer);

        await userManager.AddToRoleAsync(example, Roles.Admin);
    }
}
