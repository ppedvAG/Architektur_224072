using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Services.CarService
{
    public class CarManager
    {
        private readonly IRepository _repository;

        public CarManager(IRepository repository)
        {
            _repository = repository;
        }

        public double GetAverageKWOfAllMyCars()
        {
            return _repository.GetAll<Car>().Average(x => x.KW);
        }
    }
}