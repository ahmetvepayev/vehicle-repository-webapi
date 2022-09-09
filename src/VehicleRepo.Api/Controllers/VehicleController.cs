using Microsoft.AspNetCore.Mvc;
using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Api.Controllers;

[ApiController]
[Route("vehicles")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly ICarService _carService;

    public VehicleController(IVehicleService vehicleService, ICarService carService)
    {
        _vehicleService = vehicleService;
        _carService = carService;
    }

    [HttpGet]
    public IActionResult GetAllVehicles()
    {
        return Ok(_vehicleService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetVehicleById(int id)
    {
        return Ok(_vehicleService.GetById(id));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteVehicle(int id)
    {
        _vehicleService.Delete(id);
        
        return Ok();
    }

    [HttpGet("cars")]
    public IActionResult GetAllCars()
    {
        return Ok(_carService.GetAll());
    }

    [HttpGet("cars/{id}")]
    public IActionResult GetCarById(int id)
    {
        return Ok(_carService.GetById(id));
    }

    [HttpPost("cars")]
    public IActionResult AddCar(Car addedCar)
    {
        _carService.Add(addedCar);

        return Ok();
    }

    [HttpDelete("cars/{id}")]
    public IActionResult DeleteCar(int id)
    {
        _carService.Delete(id);

        return Ok();
    }

    [HttpPost("cars/{id}")]
    public IActionResult SwitchCarHeadlights(int id, string headlights)
    {
        _carService.SwitchHeadlights(id, headlights);

        return Ok();
    }
}