using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdGenderFk { get; set; }
        public Gender Gender { get; set;}
        public int IdPersonTypeFk { get; set; }
        public PersonType PersonType { get; set;}
        public int IdRegionFk { get; set; }
        public Region Region { get; set;}
   
    public ICollection<ClassRoom> ClassRooms { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new HashSet <Registration>();
        public ICollection<TrainerClassRoom> TrainerClassRooms { get; set; } = new HashSet <TrainerClassRoom>();
   
   
    }
}