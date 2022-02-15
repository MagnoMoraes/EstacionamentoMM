using estacionamentoMM.Model;
using estacionamentoMM.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estacionamentoMM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private CarsRepository _carRepository;

        public CarsController(CarsRepository carRepository)
        {
            this._carRepository = carRepository;
        }

        [HttpGet]
        public IEnumerable<Cars> GetCars()
        {
            return this._carRepository.GetCars();
        }

        [HttpGet("{id}")]
        public IActionResult GetCarsById(string id)
        {
            try
            {
                return Ok(this._carRepository.GetCarById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult RegisterCar(Cars car)
        {
            try
            {
                this._carRepository.RegisterCar(car);
                return CreatedAtAction(nameof(GetCarsById), new { id = car.Id }, car);
            }
            catch (Exception)
            {
                return BadRequest();                
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCar(string id)
        {
            try
            {
                this._carRepository.RemoveCar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(string id, Cars car)
        {
            try
            {
                this._carRepository.UpdateCar(id, car);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }
    }
}
