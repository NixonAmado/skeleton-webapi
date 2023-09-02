using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        private readonly SkeletonContext _context;
        public PersonRepository(SkeletonContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons
            .Include( p=> p.Registrations)
            .ToListAsync();
        }

        public override async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons
            .Include( p => p.Registrations)
            .FirstOrDefaultAsync( p => p.Id ==id);
        }


    }
