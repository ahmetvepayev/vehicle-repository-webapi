using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Interfaces;

public interface IBoatService
{
    List<Boat> GetAll();
    Boat GetById(int id);
    void Add(Boat boat);
    void Delete(int id);
}