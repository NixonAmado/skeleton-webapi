using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.interfaces;
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        //busquedas booleanas
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        //paginacion

        //agregar elementos
        void Add(T entity);
        //agregar un conjunto de elementos
        void AddRange(IEnumerable<T> entity);
        //eliminar un registro
        void Remove (T entity);
        //elimar registros
        void RemoveRange(IEnumerable<T> entities);
        //actualizar un registro
        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
        void Update(T entity);
    
    } 