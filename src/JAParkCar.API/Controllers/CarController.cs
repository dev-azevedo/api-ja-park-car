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
        public async Task<IActionResult> GetAllAsync([FromQuery] int skip = 1, [FromQuery] int take = 10)
        {
            try
            {
                var cars = await _carService.GetAllAsync(skip, take);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid car id");
                
            
            try
            {
                var car = await _carService.GetByIdAsync(id);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{carPlate}")]
        public async Task<IActionResult> GetByCarPlateAsync(string carPlate)
        {
            try
            {
                if (carPlate == string.Empty)
                    return BadRequest("Invalid car plate");
                
                var car = await _carService.GetByCarPlateAsync(carPlate);
                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync(CarCreateDto car)
        {
            try
            {
                await _carService.CreateAsync(car);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(CarUpdateDto car)
        {
            try
            {
                await _carService.UpdateAsync(car);
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
                await _carService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
