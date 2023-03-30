using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiTime.Core.Entities;

namespace TostiTime.Data.Configurations;

public class SlotConfiguration : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder
            .HasOne(e => e.Iron)
            .WithMany(d => d.Slots)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder
            .HasData(
                new Slot { Id =  1, IronId = 1 },
                new Slot { Id =  2, IronId = 1 },
                new Slot { Id =  3, IronId = 1 },
                new Slot { Id =  4, IronId = 1 },
                new Slot { Id =  5, IronId = 2 },
                new Slot { Id =  6, IronId = 2 },
                new Slot { Id =  7, IronId = 2 },
                new Slot { Id =  8, IronId = 2 },
                new Slot { Id =  9, IronId = 3 },
                new Slot { Id = 10, IronId = 3 },
                new Slot { Id = 11, IronId = 3 },
                new Slot { Id = 12, IronId = 3 },
                new Slot { Id = 13, IronId = 4 },
                new Slot { Id = 14, IronId = 4 },
                new Slot { Id = 15, IronId = 4 },
                new Slot { Id = 16, IronId = 4 },
                new Slot { Id = 17, IronId = 4 },
                new Slot { Id = 18, IronId = 4 },
                new Slot { Id = 19, IronId = 5 },
                new Slot { Id = 20, IronId = 5 },
                new Slot { Id = 21, IronId = 6 },
                new Slot { Id = 22, IronId = 6 },
                new Slot { Id = 23, IronId = 7 },
                new Slot { Id = 24, IronId = 7 },
                new Slot { Id = 25, IronId = 7 },
                new Slot { Id = 26, IronId = 7 },
                new Slot { Id = 27, IronId = 8 },
                new Slot { Id = 28, IronId = 8 },
                new Slot { Id = 29, IronId = 9 },
                new Slot { Id = 30, IronId = 9 },
                new Slot { Id = 31, IronId = 9 },
                new Slot { Id = 32, IronId = 9 },
                new Slot { Id = 33, IronId = 9 },
                new Slot { Id = 34, IronId = 9 }
            );
    }
}
