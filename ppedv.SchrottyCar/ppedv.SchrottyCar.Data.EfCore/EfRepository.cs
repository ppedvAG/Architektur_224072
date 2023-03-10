using Microsoft.EntityFrameworkCore;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Data.EfCore
{

    public class EfQueryRepository<T> : IQueryRepository<T> where T : Entity
    {
        protected readonly SchrottyContext _context;

        public EfQueryRepository(SchrottyContext context)
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

    }

    public class EfCarQueryRepository : EfQueryRepository<Car>, ICarQueryRepository
    {
        public EfCarQueryRepository(SchrottyContext context) : base(context)
        { }

        public IEnumerable<Car> GetSuperCarsByStoredProcedure()
        {
            return _context.Database.SqlQueryRaw<Car>("exec SPSPSPSPS");

        }
    }

    public class EfCommandRepository<T> : EfQueryRepository<T>, ICommandRepository<T> where T : Entity
    {
        public EfCommandRepository(SchrottyContext context) : base(context)
        { }

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

    public class EfCarCommandRepository : EfCommandRepository<Car>, EfCarQueryRepository
    {
        public EfCarCommandRepository(SchrottyContext context) : base(context)
        {
        }

   

        public void KillAllCars()
        {
            throw new NotImplementedException();
        }
    }

}
