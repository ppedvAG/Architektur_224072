using Microsoft.AspNetCore.Mvc;
using ppedv.SchrottyCar.Model.Contracts;
using ppedv.SchrottyCar.Model.DomainModel;
using ppedv.SchrottyCar.Services.CarService;
using ppedv.SchrottyCar.Web.API.Model;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.SchrottyCar.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CarController(IUnitOfWork uow)
        {
            this._uow = uow;
        }


        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            return _uow.CarRepository.Query().Select(x => CarMapper.MapToDTO(x));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarDTO Get(int id)
        {
            return CarMapper.MapToDTO(_uow.CarRepository.GetById(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] CarDTO value)
        {
            _uow.CarRepository.Add(CarMapper.MapToEntity(value));
            _uow.SaveAll();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarDTO value)
        {
            _uow.CarRepository.Update(CarMapper.MapToEntity(value));
            _uow.SaveAll();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toKill = _uow.CarRepository.GetById(id);
            _uow.CarRepository.Delete(toKill);
            _uow.SaveAll();
        }
    }
}
