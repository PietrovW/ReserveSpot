using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveSpot.Domain.Models.Reservations;

namespace ReserveSpot.Infrastructure.Persistence.Configurations;
internal sealed  class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p=>p.Name).IsRequired().HasMaxLength(256);
        builder.Property(p => p.BookingDate).IsRequired();
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
