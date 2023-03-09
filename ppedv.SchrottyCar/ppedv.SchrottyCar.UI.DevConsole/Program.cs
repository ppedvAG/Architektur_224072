using Autofac;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using ppedv.SchrottyCar.Data.EfCore;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;
using ppedv.SchrottyCar.Services.CarService;
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
builder.RegisterType<EfRepository>().AsImplementedInterfaces().WithParameter("conString", conString);
var container = builder.Build();

IRepository repo = container.Resolve<IRepository>();
CarManager cm = new CarManager(container.Resolve<IRepository>());

foreach (var car in repo.Query<Car>())
{
    Console.WriteLine($"{car.Id} {car.Manufacturer} {car.Model} {car.KW} {car.Color}");
}
Console.WriteLine($"⌀ {cm.GetAverageKWOfAllMyCars():N}");
