using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
    public class ClassRoomRepository : GenericRepository<ClassRoom>, IClassRoom
    {
        private readonly SkeletonContext _context;
        public ClassRoomRepository(SkeletonContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ClassRoom>> GetAllAsync()
        {
            return await _context.ClassRooms
            .Include( p => p.Persons)
            .ToListAsync();
        } 

        public override async Task<ClassRoom> GetByIdAsync(int id)
        {
            return await _context.ClassRooms
            .Include( p => p.Persons)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
