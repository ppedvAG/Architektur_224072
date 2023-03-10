using Microsoft.EntityFrameworkCore;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Data.EfCore
{
    public class EfCarRepository : EfRepository<Car>, ICarRepository
    {
        public EfCarRepository(SchrottyContext context) : base(context)
        {
        }
        public IEnumerable<Car> GetSuperCarsByStoredProcedure()
        {
            return _context.Database.SqlQueryRaw<Car>("exec SPSPSPSPS");

        }
        public void KillAllCars()
        {
            throw new NotImplementedException();
        }
    }

}
