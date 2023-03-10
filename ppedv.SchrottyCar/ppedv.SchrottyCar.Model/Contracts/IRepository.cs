using ppedv.SchrottyCar.Model.DomainModel;
using System.Data.Common;

namespace ppedv.SchrottyCar.Model.Contracts
{

    public interface IRepository<T> where T : Entity
    {
        T? GetById(int id);
        IQueryable<T> Query();

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }


}
