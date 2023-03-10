using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Model.Contracts
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetSuperCarsByStoredProcedure();
    }


}
