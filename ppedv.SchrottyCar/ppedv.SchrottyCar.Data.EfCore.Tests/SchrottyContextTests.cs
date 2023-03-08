using ppedv.SchrottyCar.Model;

namespace ppedv.SchrottyCar.Data.EfCore.Tests
{
    public class SchrottyContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=SchrottyDb_Tests;Trusted_Connection=true;";

        [Fact]
        public void Can_create_DB()
        {
            var con = new SchrottyContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void CanInsertCar()
        {
            // Arrange
            var con = new SchrottyContext(conString);
            var car = new Car
            {
                Manufacturer = "Toyota",
                Model = "Camry",
                KW = 100,
                BuildDate = new DateTime(2020, 1, 1),
                Color = "Red"
            };

            // Act
            con.Cars.Add(car);
            con.SaveChanges();

            // Assert
            var insertedCar = con.Cars.FirstOrDefault(x => x.Id == car.Id);
            Assert.NotNull(insertedCar);
            Assert.Equal("Toyota", insertedCar.Manufacturer);
            Assert.Equal("Camry", insertedCar.Model);
            Assert.Equal(100, insertedCar.KW);
            Assert.Equal(new DateTime(2020, 1, 1), insertedCar.BuildDate);
            Assert.Equal("Red", insertedCar.Color);
        }
    }
}