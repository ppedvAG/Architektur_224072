using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Model.Contracts.Data
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetSuperCarsByStoredProcedure();
    }


}
