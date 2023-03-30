using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiTime.Core.Entities;

namespace TostiTime.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .HasOne(e => e.Office)
            .WithMany(d => d.Persons)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder 
            .HasData( 
                new Person { Id = 1,  FirstName = "David", OfficeId = 1 },
                new Person { Id = 2,  FirstName = "Alexander", OfficeId = 1 },
                new Person { Id = 3,  FirstName = "Casper", OfficeId = 1 },
                new Person { Id = 4,  FirstName = "Marnix", OfficeId = 1 },
                new Person { Id = 5,  FirstName = "Jesse", OfficeId = 2 },
                new Person { Id = 6,  FirstName = "Judith", OfficeId = 3 },
                new Person { Id = 7,  FirstName = "Youri", OfficeId = 4 },
                new Person { Id = 8,  FirstName = "Gijs", OfficeId = 5 },
                new Person { Id = 9,  FirstName = "Jimmy", OfficeId = 6 },
                new Person { Id = 10, FirstName = "Goran", OfficeId = 7 }

            );
    }
}