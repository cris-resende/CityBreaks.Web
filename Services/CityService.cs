﻿using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Web.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;

        public CityService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities
                                 .Include(c => c.Country)
                                 .Include(c => c.Properties.Where(p => p.DeletedAt == null))
                                 .ToListAsync();
        }
        public async Task<City?> GetByNameAsync(string name)
        {
            return await _context.Cities
                                 .Where(c => EF.Functions.Collate(c.Name, "NOCASE") == EF.Functions.Collate(name, "NOCASE"))
                                 .Include(c => c.Country)
                                 .Include(c => c.Properties.Where(p => p.DeletedAt == null))
                                 .FirstOrDefaultAsync();
        }
    }
}