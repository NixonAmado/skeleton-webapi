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
        public ICollection<Person> Persons { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new HashSet <Registration>();
        public ICollection<TrainerClassRoom> TrainerClassRooms { get; set; } = new HashSet <TrainerClassRoom>();

    }
}