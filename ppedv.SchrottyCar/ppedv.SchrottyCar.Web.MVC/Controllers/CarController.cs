using Microsoft.AspNetCore.Mvc;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Web.MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly IRepository repo;

        public CarController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: CarController
        public ActionResult Index()
        {
            var cars = repo.Query<Car>().Where(x => !x.IsDeleted).ToList();

            return View(cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById<Car>(id));
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View(new Car() { Manufacturer = "NEW", Color = "Gelb" });
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                repo.Add(car);
                repo.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetById<Car>(id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                repo.Update(car);
                repo.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById<Car>(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                //throw new ExecutionEngineException();
                repo.Delete(car);
                repo.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
