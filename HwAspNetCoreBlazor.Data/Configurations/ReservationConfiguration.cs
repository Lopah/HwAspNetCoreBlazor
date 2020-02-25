using HwAspNetCoreBlazor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HwAspNetCoreBlazor.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(e => e.Room);

            builder.Property(e => e.ClientEmail)
                .IsRequired();

            builder.Property(e => e.ClientName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ClientSurname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ReservationDateTime)
                .IsRequired();

            builder.Property(e => e.ClientPhone)
                .IsRequired();

            builder.Property(e => e.Notes)
                .HasMaxLength(500);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.Id);
        }
    }
}
