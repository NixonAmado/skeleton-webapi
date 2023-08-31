using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class ClassRoom : BaseEntity
    {
        public string RoomName { get; set; }
        public int Capacity { get; set; } 
    

    }
}