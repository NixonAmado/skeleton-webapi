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
        public Gender Gender { get; set;}
        public int IdGenderFk { get; set; }
        public Country Country { get; set;}
        public int IdCountryFk { get; set; }
        public PersonType PersonType { get; set;}
        public int IdPersonTypeFk { get; set; }
        public ICollection<ClassRoom> ClassRooms { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new HashSet<Registration>();        
    }
}