using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Gender : BaseEntity
    {
       public string Description { get; set; }
       public ICollection<Person> Persons { get; set; }   
    }
}