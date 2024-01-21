// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentCar.Core.Entities;

namespace RentCar.Infrastructure.Data.Configurations;

public sealed class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.UserId)
            .HasMaxLength(50);

        builder.HasOne(e => e.User)
            .WithMany(e => e.Rentals)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Vehicle)
            .WithMany(e => e.Rentals)
            .HasForeignKey(e => e.VehicleId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Payment)
            .WithMany(e => e.Rentals)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
