using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiTime.Core.Entities;

namespace TostiTime.Data.Configurations;

public class IronConfiguration : IEntityTypeConfiguration<Iron>
{
    public void Configure(EntityTypeBuilder<Iron> builder)
    {
        builder
            .HasOne(e => e.Office)
            .WithMany(d => d.Irons)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder
            .Property(e => e.Name)
            .HasMaxLength(30);

        builder
            .HasData(
                new Iron { Id = 1, Name = "Grijs", OfficeId = 1 },
                new Iron { Id = 2, Name = "Zwart", OfficeId = 1 },
                new Iron { Id = 3, Name = "Klein", OfficeId = 5 },
                new Iron { Id = 4, Name = "Groot", OfficeId = 5 },
                new Iron { Id = 5, Name = "", OfficeId = 2 },
                new Iron { Id = 6, Name = "", OfficeId = 3 },
                new Iron { Id = 7, Name = "", OfficeId = 4 },
                new Iron { Id = 8, Name = "", OfficeId = 6 },
                new Iron { Id = 9, Name = "", OfficeId = 7 }
            );             
    }
}
