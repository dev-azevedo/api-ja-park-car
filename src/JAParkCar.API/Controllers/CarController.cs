using JAParkCar.Application.DTO.Car;
using JAParkCar.Application.Interfaces;
using JAParkCar.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JAParkCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController(ICarService carService) : ControllerBase
    {
        private readonly ICarService _carService = carService;

        [HttpGet]
        public async Task<IActionResult> GetCarsAsync()
        {
            try
            {
                var cars = await _carService.GetCarsAsync();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCarAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid car id");
                
            
            try
            {
                var car = await _carService.GetCarAsync(id);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{carPlate}")]
        public async Task<IActionResult> GetCarPlateAsync(string carPlate)
        {
            try
            {
                if (carPlate == string.Empty)
                    return BadRequest("Invalid car plate");
                
                var car = await _carService.GetCarPlateAsync(carPlate);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> PostCarAsync(CarCreateDto car)
        {
            try
            {
                await _carService.RegisterCar(car);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutCarAsync(CarUpdateDto car)
        {
            try
            {
                await _carService.UpdateCar(car);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCarAsync(Guid id)
        {
            try
            {
                await _carService.DeleteCarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
