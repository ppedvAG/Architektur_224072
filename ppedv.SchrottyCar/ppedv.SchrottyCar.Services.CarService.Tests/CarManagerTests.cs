using FluentAssertions;
using Moq;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Services.CarService.Tests
{
    public class CarManagerTests
    {
        [Fact]
        public void GetFastestCarColor_2_cars_diff_color_returns_red()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            var cars = new List<Car>
            {
                new Car { Manufacturer = "Toyota", Model = "Camry", KW = 150, Color = "Blue" },
                new Car { Manufacturer = "Honda", Model = "Accord", KW = 180, Color = "Red" },
            };
            mockRepo.Setup(x => x.Query<Car>()).Returns(cars.AsQueryable());
            var carManager = new CarManager(mockRepo.Object);

            // Act
            var fastestColor = carManager.GetFastestCarColor();

            // Assert
            Assert.Equal("Red", fastestColor);
        }

        [Fact]
        public void GetFastestCarColor_7_cars_diff_color_returns_red()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            var cars = new List<Car>
            {
            new Car { Manufacturer = "Toyota", Model = "Camry", KW = 150, Color = "Black" },
            new Car { Manufacturer = "Honda", Model = "Accord", KW = 180, Color = "Red" },
            new Car { Manufacturer = "BMW", Model = "M5", KW = 350, Color = "Black" },
            new Car { Manufacturer = "Mercedes-Benz", Model = "S-Class", KW = 300, Color = "Red" },
            new Car { Manufacturer = "Audi", Model = "A8", KW = 250, Color = "Black" },
            new Car { Manufacturer = "Tesla", Model = "Model S", KW = 400, Color = "Red" },
            new Car { Manufacturer = "Ford", Model = "Mustang", KW = 200, Color = "Black" }
            };
            mockRepo.Setup(x => x.Query<Car>()).Returns(cars.AsQueryable());
            var carManager = new CarManager(mockRepo.Object);

            // Act
            var fastestColor = carManager.GetFastestCarColor();

            // Assert
            Assert.Equal("Red", fastestColor);
        }

        [Fact]
        public void GetFastestCarColor_0_cars_returns_null()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            var cars = new List<Car>();
            mockRepo.Setup(x => x.Query<Car>()).Returns(cars.AsQueryable());
            var carManager = new CarManager(mockRepo.Object);
            
            carManager.GetFastestCarColor().Should().BeNull();
        }
    }
}