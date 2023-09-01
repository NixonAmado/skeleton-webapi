using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Region: BaseEntity
    {
        public string RegionName { get; set; }
        public int IdStateFk  { get; set; }
        public State State { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}