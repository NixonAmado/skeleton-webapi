using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Registration : BaseEntity
    {
        public Person Person { get; set; }
        public int IdPersonFk { get; set; }
        public ICollection<ClassRoom> ClassRooms { get; set; }

    }
}