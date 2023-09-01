using Dominio.Entities;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Persistencia.Repository
{
    public class CountryRepository : GenericRepository<Country>,ICountry
    {
        private readonly SkeletonContext _context;
        public CountryRepository(SkeletonContext context) : base(context)
        {
            _context = context;
        }
        
        public override async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries
            .Include(p => p.States)
            .ToListAsync();
        }

        public override async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries
            .Include(p => p.States)
            .FirstOrDefaultAsync(p => p.Id == id);
        } 
    }
}