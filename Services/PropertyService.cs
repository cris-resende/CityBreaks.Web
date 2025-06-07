using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using System;
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
    }
}
