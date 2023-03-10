using ppedv.SchrottyCar.Model.Contracts.Data;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Data.EfCore
{

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly SchrottyContext _context;

        public EfRepository(SchrottyContext context)
        {
            _context = context;
        }


        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }

}
