using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCar.Core.Identity;

namespace RentCar.Infrastructure.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(p => p.FirstName)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.LastName)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.CardId)
            .IsRequired()
            .HasMaxLength(12);

        builder.Property(p => p.LicenseId)
            .IsRequired()
            .HasMaxLength(12);

        builder.Property(p => p.Address)
            .IsUnicode()
            .HasColumnType("jsonb");
    }
}
