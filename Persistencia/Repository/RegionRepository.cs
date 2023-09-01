using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Persistencia.Repository
{
    public class RegionRepository : GenericRepository<Region>, IRegion
    {
        private readonly SkeletonContext _context;

        public RegionRepository(SkeletonContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions
            .Include(p=> p.Persons)
            .ToListAsync();
        }

        public override async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regions
            .Include(p=> p.Persons)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}