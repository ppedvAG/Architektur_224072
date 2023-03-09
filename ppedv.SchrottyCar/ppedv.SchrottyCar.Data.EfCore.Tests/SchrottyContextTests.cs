using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ppedv.SchrottyCar.Model;
using ppedv.SchrottyCar.Model.DomainModel;
using System.Reflection;

namespace ppedv.SchrottyCar.Data.EfCore.Tests
{
    public class SchrottyContextTests
    {
        readonly string conString = "Server=(localdb)\\mssqllocaldb;Database=SchrottyDb_Tests;Trusted_Connection=true;";

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_create_DB()
        {
            var con = new SchrottyContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }


        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Insert_and_Read_OrderFullGraph_AutoFix()
        {
            var fix = new Fixture();

            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            var order = fix.Build<Order>().Create();

            using (var con = new SchrottyContext(conString))
            {
                con.Add(order);
                con.SaveChanges();
            }

            using (var con = new SchrottyContext(conString))
            {
                //eager loading
                //var loaded = con.Orders.Include(x => x.Customer).ThenInclude(x => x.HomeAddress)
                //                       .Include(x => x.BillingAddress).ThenInclude(x => x.BillingOrders)
                //                       .Include(x => x.BillingAddress).ThenInclude(x => x.DeliveryOrders)
                //                       .Include(x => x.BillingAddress).ThenInclude(x => x.CustomerHomes)
                //                       .Include(x => x.DeliveryAddress).ThenInclude(x => x.DeliveryOrders)
                //                       .Include(x => x.DeliveryAddress).ThenInclude(x => x.BillingOrders)
                //                       .Include(x => x.DeliveryAddress).ThenInclude(x => x.CustomerHomes)
                //                       .Include(x => x.OrderItems).ThenInclude(x => x.Car)
                //                       .FirstOrDefault(x => x.Id == order.Id);

                //lazy-loading
                var loaded = con.Orders.Find(order.Id);

                loaded.Should().BeEquivalentTo(order, c => c.IgnoringCyclicReferences());
            }
        }


        [Fact]
        [Trait("Category","Integration")]
        public void Delete_Order_should_delete_OrderItems_but_not_the_car()
        {
            var car = new Car() { Model = "X" };
            var order = new Order();
            var orderItem = new OrderItem { Car = car };
            order.OrderItems.Add(orderItem);

            using (var con = new SchrottyContext(conString))
            {
                con.Add(order);
                con.SaveChanges();
            }

            using (var con = new SchrottyContext(conString))
            {
                var loaded = con.Orders.Find(order.Id);
                con.Orders.Remove(loaded!);
                con.SaveChanges();
            }

            using (var con = new SchrottyContext(conString))
            {
                con.Orders.Find(order.Id).Should().BeNull();
                con.OrderItems.Find(orderItem.Id).Should().BeNull();
                con.Cars.Find(car.Id).Should().NotBeNull();
            }
        }

        /// <Author>
        /// chatGTP
        /// </Author>
        [Fact]
        [Trait("Category", "Integration")]
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


    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}