using ppedv.SchrottyCar.Data.EfCore;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;
using ppedv.SchrottyCar.Services.CarService;

Console.OutputEncoding=System.Text.Encoding.UTF8;
Console.WriteLine("*** SchrottyCar v0.1 ***");
string conString = "Server=(localdb)\\mssqllocaldb;Database=SchrottyDb_Tests;Trusted_Connection=true;";

IRepository repo = new EfRepository(conString);
CarManager cm = new CarManager(repo);


foreach (var car in repo.GetAll<Car>())
{
    Console.WriteLine($"{car.Id} {car.Manufacturer} {car.Model} {car.KW} {car.Color}");
}
Console.WriteLine($"⌀ {cm.GetAverageKWOfAllMyCars():N}");
