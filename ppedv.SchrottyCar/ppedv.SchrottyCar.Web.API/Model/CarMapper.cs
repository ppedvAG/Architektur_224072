using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Web.API.Model
{
    public static class CarMapper
    {
        public static CarDTO MapToDTO(Car car)
        {
            return new CarDTO
            {
                Manufacturer = car.Manufacturer,
                Model = car.Model,
                KW = car.KW,
                BuildDate = car.BuildDate,
                Color = car.Color,
                Id = car.Id
            };
        }

        public static Car MapToEntity(CarDTO carDTO)
        {
            return new Car
            {
                Manufacturer = carDTO.Manufacturer,
                Model = carDTO.Model,
                KW = carDTO.KW,
                BuildDate = carDTO.BuildDate,
                Color = carDTO.Color,
                Id = carDTO.Id
            };
        }
    }
}
