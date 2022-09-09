using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Interfaces;

public interface ICarService
{
    List<Car> GetAll();
    Car GetById(int id);
    void Add(Car car);
    void Delete(int id);
    public void SwitchHeadlights(int id, string headlights);
}