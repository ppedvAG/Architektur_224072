using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Services.CarService
{
    public class CarManager
    {
        
        private readonly IUnitOfWork unitOfWork;

        public CarManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public double GetAverageKWOfAllMyCars()
        {
            return unitOfWork.CarRepository.Query().Average(x => x.KW);
        }

        public string? GetFastestCarColor()
        {
            return unitOfWork.CarRepository.Query()
                              .GroupBy(c => c.Color)
                              .OrderByDescending(x => x.Average(y => y.KW))
                              .FirstOrDefault()?.Key;
        }
    }
}