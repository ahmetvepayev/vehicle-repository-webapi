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
    private readonly IBusService _busService;
    private readonly IBoatService _boatService;

    public VehicleController(IVehicleService vehicleService, ICarService carService, IBusService busService, IBoatService boatService)
    {
        _vehicleService = vehicleService;
        _carService = carService;
        _busService = busService;
        _boatService = boatService;
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

    [HttpGet("color/{color}")]
    public IActionResult GetVehiclesByColor(string color)
    {
        return Ok(_vehicleService.GetAllByColor(color));
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

    [HttpGet("cars/color/{color}")]
    public IActionResult GetCarsByColor(string color)
    {
        return Ok(_carService.GetAllByColor(color));
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

    [HttpGet("buses")]
    public IActionResult GetAllBuses()
    {
        return Ok(_busService.GetAll());
    }

    [HttpGet("buses/{id}")]
    public IActionResult GetBusById(int id)
    {
        return Ok(_busService.GetById(id));
    }

    [HttpGet("buses/color/{color}")]
    public IActionResult GetBusesByColor(string color)
    {
        return Ok(_busService.GetAllByColor(color));
    }

    [HttpPost("buses")]
    public IActionResult AddBus(Bus addedBus)
    {
        _busService.Add(addedBus);

        return Ok();
    }

    [HttpDelete("buses/{id}")]
    public IActionResult DeleteBus(int id)
    {
        _busService.Delete(id);

        return Ok();
    }

    [HttpGet("boats")]
    public IActionResult GetAllBoats()
    {
        return Ok(_boatService.GetAll());
    }

    [HttpGet("boats/{id}")]
    public IActionResult GetBoatById(int id)
    {
        return Ok(_boatService.GetById(id));
    }

    [HttpGet("boats/color/{color}")]
    public IActionResult GetBoatsByColor(string color)
    {
        return Ok(_boatService.GetAllByColor(color));
    }

    [HttpPost("boats")]
    public IActionResult AddBoat(Boat addedBoat)
    {
        _boatService.Add(addedBoat);

        return Ok();
    }

    [HttpDelete("boats/{id}")]
    public IActionResult DeleteBoat(int id)
    {
        _boatService.Delete(id);

        return Ok();
    }
}