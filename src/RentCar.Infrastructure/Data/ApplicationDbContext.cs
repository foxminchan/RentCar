﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentCar.Core.Entities;
using RentCar.Core.Identity;

namespace RentCar.Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options), IDatabaseFacade
{
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Rental> Rentals => Set<Rental>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<Maintenance> Maintenances => Set<Maintenance>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
