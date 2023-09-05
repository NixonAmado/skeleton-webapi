using Dominio.Entities;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;


namespace Aplicacion.Repository;

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
            .ThenInclude(p => p.Regions)
            .ToListAsync();
        }

        public override async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries
            .Include(p => p.States)
            .FirstOrDefaultAsync(p => p.Id == id);
        } 

        public override async Task<(int totalRegistros, IEnumerable<Country> registros)> GetAllAsync (int pageIndex, int pageSize, string search)
        {
            var query = _context.Countries as IQueryable<Country>;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.CountryName.ToLower().Contains(search));    
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                      .Include(u => u.States)
                                      .Skip((pageIndex - 1) * pageSize)
                                      .Take(pageSize) 
                                      .ToListAsync();
            return (totalRegistros, registros);
        }
    }
