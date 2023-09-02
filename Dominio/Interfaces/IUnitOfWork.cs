using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.interfaces;

namespace Dominio.Interfaces;

    public interface IUnitOfWork
    {
        IState States {get; }
        IRegion Regions {get; }
        IGender Genders {get; }
        IPerson Persons {get; }
        ICountry Countries {get; }
        IClassRoom classRooms {get; }
        IPersonType PersonTypes {get; }
        //IRegistration RegistIRegistration {get; }
        Task<int> SaveAsync();
    
    }