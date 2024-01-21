// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentCar.Core.Entities;

namespace RentCar.Infrastructure.Data.Configurations;

public sealed class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(e => e.Vehicle)
            .WithMany(e => e.Maintenances)
            .HasForeignKey(e => e.VehicleId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
