// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentCar.Core.Entities;

namespace RentCar.Infrastructure.Data.Configurations;

public sealed class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Message)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(e => e.Rental)
            .WithMany(e => e.Feedbacks)
            .HasForeignKey(e => e.RentalId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
