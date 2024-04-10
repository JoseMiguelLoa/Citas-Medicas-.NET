using Azure;
using CitasMedicas.Context;
using CitasMedicas.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Linq.Expressions;
using System.Text;

namespace CitasMedicas.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CitasMedicasDbContext _context; //Contexto de la base de datos de citas médicas
        public GenericRepository(CitasMedicasDbContext context) 
        { 
            _context = context;
        }
        //Método que realiza la inserción de una entidad en la base de datos
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        //Método que realiza la inserción de varias entidades en la base de datos
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        //Método que realiza la busqueda de entidades que cumplan ciertos criterios y las devuelve
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);  
        }
        //Método que devuelve todas las entidades de T
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        //Método que realiza la busqueda de una entidad con id pasado por parámetro
        public T GetById(long id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
                throw new Exception($"La entidad de tipo {typeof(T).Name} con Id {id} no se encontró.");


            return entity;           
        }

        //Método que realiza el borrado de una entidad que se le haya pasado por parámetro
        public void Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en la solicitud de borrado.");
            }  
        }

        //Método que realiza el borrade de entidades que se les haya pasado por parámetro
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        //Método que realiza la actualización de una entidad pasada por parámetro
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
