using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CountryCode).IsRequired().HasMaxLength(2);
            builder.Property(c => c.CountryName).IsRequired().HasMaxLength(100).HasColumnName("Name");

            builder.HasData(
                new Country { Id = 1, CountryCode = "BR", CountryName = "Brasil" },
                new Country { Id = 2, CountryCode = "US", CountryName = "Estados Unidos" },
                new Country { Id = 3, CountryCode = "CA", CountryName = "Canadá" }
            );
        }
    }
}
