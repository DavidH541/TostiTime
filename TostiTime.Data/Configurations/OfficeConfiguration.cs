using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiTime.Core.Entities;

namespace TostiTime.Data.Configurations;

public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder
            .Property(e => e.City)
            .HasMaxLength(40);
        
        builder
            .Property(e => e.Country)
            .HasMaxLength(40);

        builder
            .HasData(
                new Office { Id = 1, Country = "The Netherlands", City = "Rotterdam", CityCode = "010", Address = "K.P. van der Mandelelaan 60", PostalCode = "3062 MB" },
                new Office { Id = 2, Country = "The Netherlands", City = "Amsterdam", CityCode = "020", Address = "Joop Geesinkweg 801",         PostalCode = "1114 AB" },
                new Office { Id = 3, Country = "The Netherlands", City = "The Hague", CityCode = "070", Address = "Oude Middenweg 17",           PostalCode = "2491 AC" },
                new Office { Id = 4, Country = "The Netherlands", City = "Utrecht",   CityCode = "030", Address = "Burgemeester Verderlaan 15b", PostalCode = "3544 AD" },
                new Office { Id = 5, Country = "The Netherlands", City = "Eindhoven", CityCode = "040", Address = "Flight Forum 86",             PostalCode = "5657 DC" },
                new Office { Id = 6, Country = "The Netherlands", City = "Apeldoorn", CityCode = "055", Address = "J.C. Wilslaan 29",            PostalCode = "7313 HK" },
                new Office { Id = 7, Country = "Serbia",          City = "Belgrade",  CityCode = "011", Address = "Vladimira Popovića 40",       PostalCode = "11000"   } 
            );
    }
}
