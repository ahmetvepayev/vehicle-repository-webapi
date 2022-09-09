using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Interfaces;

public interface IVehicleService
{
    List<Vehicle> GetAll();
    Vehicle GetById(int id);
    void Delete(int id);
}