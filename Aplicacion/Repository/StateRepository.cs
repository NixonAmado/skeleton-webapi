
using Dominio.Entities;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
namespace Aplicacion.Repository;
    public class StateRepository : GenericRepository<State>, IState
    {
        private readonly SkeletonContext _context;
        public StateRepository(SkeletonContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _context.States
            .Include( p => p.Regions)
            .ToListAsync();
        }

        public override async Task<State> GetByIdAsync(int id)
        {
            return await _context.States
            .Include( p => p.Regions)
            .FirstOrDefaultAsync( p => p.Id ==id);
        }

    }
