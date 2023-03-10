using ppedv.SchrottyCar.Model.DomainModel;
using System.Data.Common;

namespace ppedv.SchrottyCar.Model.Contracts
{

    public interface IQueryRepository<out T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        T? GetById(int id);
        IQueryable<T> Query();
    }

    public interface ICarQueryRepository : IQueryRepository<Car>
    {
        IEnumerable<Car> GetSuperCarsByStoredProcedure();
    }


    public interface ICommandRepository<in T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    public interface ICarCommandRepository : ICommandRepository<Car>
    {
        void KillAllCars();

    }
}
