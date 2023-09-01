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
    public class PersonTypeRepository : GenericRepository<PersonType>, IPersonType
    {
        private readonly SkeletonContext _context;
        public PersonTypeRepository(SkeletonContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<PersonType>> GetAllAsync()
        {
            return await _context.PersonTypes
            .Include( p=> p.Persons)
            .ToListAsync();
        }

        public override async Task<PersonType> GetByIdAsync(int id)
        {
            return await _context.PersonTypes
            .Include( p => p.Persons)
            .FirstOrDefaultAsync( p => p.Id ==id);
        }


    }
}