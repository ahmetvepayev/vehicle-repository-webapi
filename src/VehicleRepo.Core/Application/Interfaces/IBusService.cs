using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Interfaces;

public interface IBusService
{
    List<Bus> GetAll();
    Bus GetById(int id);
    void Add(Bus bus);
    void Delete(int id);
}