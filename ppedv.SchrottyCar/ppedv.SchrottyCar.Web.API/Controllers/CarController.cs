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
        private readonly IRepository repo;

        public CarController(IRepository repo)
        {
            this.repo = repo;
        }


        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            return repo.Query<Car>().Select(x => CarMapper.MapToDTO(x));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarDTO Get(int id)
        {
            return CarMapper.MapToDTO(repo.GetById<Car>(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] CarDTO value)
        {
            repo.Add(CarMapper.MapToEntity(value));
            repo.SaveAll();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarDTO value)
        {
            repo.Update(CarMapper.MapToEntity(value));
            repo.SaveAll();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toKill = repo.GetById<Car>(id);
            repo.Delete(toKill);
            repo.SaveAll();
        }
    }
}
