using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiTime.Core.Entities;

namespace TostiTime.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(e => new { e.SlotId, e.PersonId, e.OccupiedSince });

            builder
                .HasOne(e => e.Slot)
                .WithMany(d => d.Reservations)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .HasOne(e => e.Person)
                .WithMany(d => d.Reservations)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
