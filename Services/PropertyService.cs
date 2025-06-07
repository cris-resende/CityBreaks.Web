using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Web.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var propertyToDelete = await _context.Properties.FindAsync(id);

            if (propertyToDelete != null)
            {
                propertyToDelete.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName)
        {
            IQueryable<Property> query = _context.Properties;

            query = query.Where(p => p.DeletedAt == null);

            query = query.Include(p => p.City)
                         .ThenInclude(c => c.Country);

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight <= maxPrice.Value);
            }

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                query = query.Where(p => EF.Functions.Collate(p.City.Name, "NOCASE") == EF.Functions.Collate(cityName, "NOCASE"));
            }

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                query = query.Where(p => EF.Functions.Collate(p.Name, "NOCASE").Contains(EF.Functions.Collate(propertyName, "NOCASE")));
            }

            return await query.ToListAsync();
        }
    }
}
