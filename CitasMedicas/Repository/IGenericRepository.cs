using System.Linq.Expressions;

namespace CitasMedicas.Repository
{
    public interface IGenericRepository<T> where T : class //Repositorio genérico 
    {
        T GetById(long id); //Método que realiza la busqueda de una entidad con id pasado por parámetro

        IEnumerable<T> GetAll();  //Método que devuelve todas las entidades de T
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate); //Método que realiza la busqueda de entidades que cumplan ciertos criterios y las devuelve
        void Add(T entity); //Método que realiza la inserción de una entidad en la base de datos

        void AddRange(IEnumerable<T> entities);//Método que realiza la inserción de varias entidades en la base de datos

        void Update(T entity); //Método que realiza la actualización de una entidad pasada por parámetro
        void Remove(T entity); //Método que realiza el borrado de una entidad que se le haya pasado por parámetro
        void RemoveRange(IEnumerable<T> entities); //Método que realiza el borrade de entidades que se les haya pasado por parámetro
    }
}
