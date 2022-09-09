using Microsoft.AspNetCore.Mvc;
using VehicleRepo.Api.Extensions;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BoatDtos;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BusDtos;
using VehicleRepo.Core.Application.Dtos.EntityDtos.CarDtos;
using VehicleRepo.Core.Application.Interfaces;

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
        var response = _vehicleService.GetAll();

        return response.GetActionResult();
    }

    [HttpGet("{id}")]
    public IActionResult GetVehicleById(int id)
    {
        var response = _vehicleService.GetById(id);

        return response.GetActionResult();
    }

    [HttpGet("color/{color}")]
    public IActionResult GetVehiclesByColor(string color)
    {
        var response = _vehicleService.GetAllByColor(color);

        return response.GetActionResult();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteVehicle(int id)
    {
        var response = _vehicleService.Delete(id);

        return response.GetActionResult();
    }

    [HttpGet("cars")]
    public IActionResult GetAllCars()
    {
        var response = _carService.GetAll();

        return response.GetActionResult();
    }

    [HttpGet("cars/{id}")]
    public IActionResult GetCarById(int id)
    {
        var response = _carService.GetById(id);

        return response.GetActionResult();
    }

    [HttpGet("cars/color/{color}")]
    public IActionResult GetCarsByColor(string color)
    {
        var response = _carService.GetAllByColor(color);

        return response.GetActionResult();
    }

    [HttpPost("cars")]
    public IActionResult AddCar(CarAddRequest request)
    {
        var response = _carService.Add(request);

        return response.GetActionResult();
    }

    [HttpDelete("cars/{id}")]
    public IActionResult DeleteCar(int id)
    {
        var response = _carService.Delete(id);

        return response.GetActionResult();
    }

    [HttpPost("cars/{id}")]
    public IActionResult SwitchCarHeadlights(int id, string headlights)
    {
        var response = _carService.SwitchHeadlights(id, headlights);

        return response.GetActionResult();
    }

    [HttpGet("buses")]
    public IActionResult GetAllBuses()
    {
        var response = _busService.GetAll();

        return response.GetActionResult();
    }

    [HttpGet("buses/{id}")]
    public IActionResult GetBusById(int id)
    {
        var response = _busService.GetById(id);

        return response.GetActionResult();
    }

    [HttpGet("buses/color/{color}")]
    public IActionResult GetBusesByColor(string color)
    {
        var response = _busService.GetAllByColor(color);

        return response.GetActionResult();
    }

    [HttpPost("buses")]
    public IActionResult AddBus(BusAddRequest request)
    {
        var response = _busService.Add(request);

        return response.GetActionResult();
    }

    [HttpDelete("buses/{id}")]
    public IActionResult DeleteBus(int id)
    {
        var response = _busService.Delete(id);

        return response.GetActionResult();
    }

    [HttpGet("boats")]
    public IActionResult GetAllBoats()
    {
        var response = _boatService.GetAll();

        return response.GetActionResult();
    }

    [HttpGet("boats/{id}")]
    public IActionResult GetBoatById(int id)
    {
        var response = _boatService.GetById(id);

        return response.GetActionResult();
    }

    [HttpGet("boats/color/{color}")]
    public IActionResult GetBoatsByColor(string color)
    {
        var response = _boatService.GetAllByColor(color);

        return response.GetActionResult();
    }

    [HttpPost("boats")]
    public IActionResult AddBoat(BoatAddRequest request)
    {
        var response = _boatService.Add(request);

        return response.GetActionResult();
    }

    [HttpDelete("boats/{id}")]
    public IActionResult DeleteBoat(int id)
    {
        var response = _boatService.Delete(id);

        return response.GetActionResult();
    }
}