using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentCar.Core.Entities;

namespace RentCar.Infrastructure.Data.Configurations;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.CardNumber)
            .HasMaxLength(19)
            .IsRequired();

        builder.Property(p => p.CardHolderName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.SecurityCode)
            .HasMaxLength(3)
            .IsRequired();
    }
}
