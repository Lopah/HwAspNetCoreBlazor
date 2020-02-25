using HwAspNetCoreBlazor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HwAspNetCoreBlazor.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasMany(e => e.Reservations)
                .WithOne(e => e.Room);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.OpeningTimeFrom)
                .IsRequired();

            builder.Property(e => e.OpeningTimeTo)
                .IsRequired();

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.Id);
        }
    }
}
