using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;


    public class GenderRepository : GenericRepository<Gender>, IGender
    {
        protected readonly SkeletonContext _context;
        public GenderRepository(SkeletonContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _context.Genders
            .Include(g => g.Persons)
            .ToListAsync();
        }
    }
        // public override async Task<Gender> GetByIdAsync(int id)
        // {
        //     return await _context.Genders
        //     .Include( p => p.Registrations)
        //     .FirstOrDefaultAsync( p => p.Id ==id);
        // }
