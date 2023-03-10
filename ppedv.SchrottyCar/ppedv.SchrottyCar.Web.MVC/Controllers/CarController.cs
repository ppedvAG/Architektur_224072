using Microsoft.AspNetCore.Mvc;
using ppedv.SchrottyCar.Model.Contracts.Data;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Web.MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CarController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: CarController
        public ActionResult Index()
        {
            var cars = _uow.CarRepository.Query().Where(x => !x.IsDeleted).ToList();

            return View(cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(_uow.CarRepository.GetById(id));
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
                _uow.CarRepository.Add(car);
                _uow.SaveAll();

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
            return View(_uow.CarRepository.GetById(id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                _uow.CarRepository.Update(car);
                _uow.SaveAll();

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
            return View(_uow.CarRepository.GetById(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                //throw new ExecutionEngineException();
                _uow.CarRepository.Delete(car);
                _uow.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
