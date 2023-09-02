
using Aplicacion.Repository;
using Dominio.interfaces;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SkeletonContext _context;
        private IClassRoom _classRooms;
        private ICountry _countries;
        private IGender _genders;
        private IPerson _persons;
        private IPersonType _personTypes;
        private IRegion _regions;
        private IState _states;        
        public UnitOfWork(SkeletonContext Context)
        {
            _context = Context;
        }

        public IClassRoom classRooms
        {
            get{
                if (_classRooms == null)
                {
                    _classRooms = new ClassRoomRepository(_context);
                }
                return _classRooms;
            }
        }
        public ICountry Countries
        {
            get{
                if(_countries == null)
                {
                    _countries = new CountryRepository(_context);
                }
                return _countries;
            }
        }
        public IGender Genders 
        {
            get{
                if(_genders == null)
                {
                    _genders = new GenderRepository(_context);
                }
                return _genders;
            }
        }
        public IPerson Persons 
        {
            get{
                if(_persons == null)
                {
                    _persons = new PersonRepository(_context);
                }
                return _persons;
            }
        }
        public IPersonType PersonTypes 
        {
            get{
                if(_personTypes == null)
                {
                    _personTypes = new PersonTypeRepository(_context);
                }
                return _personTypes;
            }
        }
        public IRegion Regions 
        {
            get{
                if(_regions == null)
                {
                    _regions = new RegionRepository(_context);
                }
                return _regions;
            }
        }
        public IState States 
        {
            get{
                if(_states == null)
                {
                    _states = new StateRepository(_context);
                }
                return _states;
            }
        }
        public void  Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }        
    }
}
