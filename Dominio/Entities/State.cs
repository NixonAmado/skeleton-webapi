using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class State: BaseEntity
    {
        public string StateName { get; set; }
        public int IdCountryFk  { get; set; }
        public Country Country { get; set; }
        public ICollection <Region> Regions { get; set; }
    }
}