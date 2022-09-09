using Microsoft.AspNetCore.Mvc;
using VehicleRepo.Core.Application.Interfaces;

namespace VehicleRepo.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
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
}