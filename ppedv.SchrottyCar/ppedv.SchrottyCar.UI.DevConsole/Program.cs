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
builder.RegisterType<SchrottyContext>().As<IUnitOfWork>().AsSelf().WithParameter("conString", conString).SingleInstance();
builder.RegisterGeneric(typeof(EfQueryRepository<>)).As(typeof(IQueryRepository<>)).WithParameter((pi, ctx) => pi.ParameterType == typeof(SchrottyContext) && pi.Name == "context",
                          (pi, ctx) => ctx.Resolve<SchrottyContext>());
//builder.RegisterGeneric(typeof(EfQueryRepository<>)).As(typeof(IQueryRepository<>)).WithParameter("context",)
//builder.RegisterType(typeof(EfCarQueryRepository)).As(typeof(ICarQueryRepository));
//builder.RegisterGeneric(typeof(EfCommandRepository<>)).As(typeof(ICommandRepository<>));
//builder.RegisterType(typeof(EfCarCommandRepository)).As(typeof(ICarCommandRepository));
var container = builder.Build();

//IUnitOfWork uow = container.Resolve<IUnitOfWork>();
//CarManager cm = new CarManager(container.Resolve<IUnitOfWork>());

//foreach (var car in uow.CarRepository.Query())
foreach (var car in container.Resolve<IQueryRepository<Car>>().Query())
{
    Console.WriteLine($"{car.Id} {car.Manufacturer} {car.Model} {car.KW} {car.Color}");
}
//Console.WriteLine($"⌀ {cm.GetAverageKWOfAllMyCars():N}");
