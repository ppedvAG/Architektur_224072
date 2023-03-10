using Autofac;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using ppedv.SchrottyCar.Data.EfCore;
using ppedv.SchrottyCar.Model.Contracts.Data;
using ppedv.SchrottyCar.Model.Contracts.Service;
using ppedv.SchrottyCar.Model.DomainModel;
using ppedv.SchrottyCar.Services.CarService;
using ppedv.SchrottyCar.Services.CustomerServices;
using ppedv.SchrottyCar.Services.OrderService;
using System.Reflection;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("*** SchrottyCar v0.1 ***");
string conString = "Server=(localdb)\\mssqllocaldb;Database=SchrottyDb_Tests;Trusted_Connection=true;";

//DI manuell per code
//IRepository repo = new EfRepository(conString);
//CarManager cm = new CarManager(repo);

//DI per Refection
//var path = @"C:\Users\Fred\source\repos\ppedvAG\Architektur_224072\ppedv.SchrottyCar\ppedv.SchrottyCar.Data.EfCore\bin\Debug\net7.0\ppedv.SchrottyCar.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = (IRepository)Activator.CreateInstance(typeMitRepo, conString);
//CarManager cm = new CarManager(repo);

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfUnitOfWork>().AsImplementedInterfaces().WithParameter("conString", conString);
builder.RegisterType<OrderManager>().AsImplementedInterfaces();
builder.RegisterType<CarManager>().AsImplementedInterfaces();
builder.RegisterType<CustomerManager>().AsImplementedInterfaces();
var container = builder.Build();

IUnitOfWork uow = container.Resolve<IUnitOfWork>();
ICarService cm = container.Resolve<ICarService>();

foreach (var car in uow.CarRepository.Query())
{
    Console.WriteLine($"{car.Id} {car.Manufacturer} {car.Model} {car.KW} {car.Color}");
}
Console.WriteLine($"⌀ {cm.GetAverageKWOfAllMyCars():N}");



IOrderService os = container.Resolve<IOrderService>();
var order = new Order() { };
order.Customer = new Customer() { CustomerId = "AABABABABABA", HomeAddress = new Address() { Adress = "StrassStrasse 99, 2827826 StadtDtadt" } };
os.SaveNewOrder(order);

