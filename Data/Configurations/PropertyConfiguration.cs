using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250).HasColumnName("PropertyName");
            builder.Property(p => p.PricePerNight).IsRequired().HasColumnType("TEXT");
            builder.HasOne(p => p.City).WithMany(c => c.Properties).HasForeignKey(p => p.CityId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            // Adicione o método HasData para inserir propriedades
            builder.HasData(
                new Property { Id = 1, CityId = 1, Name = "Apartamento Copacabana", PricePerNight = 250.00M },
                new Property { Id = 2, CityId = 1, Name = "Hotel Ipanema", PricePerNight = 400.00M },
                new Property { Id = 3, CityId = 3, Name = "Times Square Studio", PricePerNight = 300.00M },
                new Property { Id = 4, CityId = 4, Name = "Hollywood Hills Villa", PricePerNight = 600.00M },
                new Property { Id = 5, CityId = 5, Name = "CN Tower View Condo", PricePerNight = 200.00M },
                new Property { Id = 6, CityId = 6, Name = "Stanley Park Cottage", PricePerNight = 350.00M }
            );
        }
    }
}
