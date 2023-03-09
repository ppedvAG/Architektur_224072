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
            return _repository.Query<Car>().Average(x => x.KW);
        }

        public string? GetFastestCarColor()
        {
            return _repository.Query<Car>()
                              .GroupBy(c => c.Color)
                              .OrderByDescending(x => x.Average(y => y.KW))
                              .FirstOrDefault()?.Key;
        }
    }
}