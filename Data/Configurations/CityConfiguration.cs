using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100).HasColumnName("CityName");
            builder.HasOne(c => c.Country).WithMany(co => co.Cities).HasForeignKey(c => c.CountryId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new City { Id = 1, CountryId = 1, Name = "Rio de Janeiro" },
                new City { Id = 2, CountryId = 1, Name = "São Paulo" },
                new City { Id = 3, CountryId = 2, Name = "Nova Iorque" },
                new City { Id = 4, CountryId = 2, Name = "Los Angeles" },
                new City { Id = 5, CountryId = 3, Name = "Toronto" },
                new City { Id = 6, CountryId = 3, Name = "Vancouver" }
            );
        }
    }
}
