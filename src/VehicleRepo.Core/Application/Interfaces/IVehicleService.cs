using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Interfaces;

public interface IVehicleService
{
    List<Vehicle> GetAll();
    Vehicle GetById(int id);
    List<Vehicle> GetAllByColor(string color);
    void Delete(int id);
}