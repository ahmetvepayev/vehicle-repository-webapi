using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class BoatService : PersistingServiceBase, IBoatService
{
    private readonly IBoatRepository _boatRepository;

    public BoatService(IUnitOfWork unitOfWork, IBoatRepository boatRepository) : base(unitOfWork)
    {
        _boatRepository = boatRepository;
    }

    public void Add(Boat boat)
    {
        _boatRepository.Add(boat);

        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        var deletedBoat = _boatRepository.GetById(id);
        _boatRepository.Delete(deletedBoat);

        _unitOfWork.SaveChanges();
    }

    public List<Boat> GetAll()
    {
        return _boatRepository.GetAll();
    }

    public Boat GetById(int id)
    {
        return _boatRepository.GetById(id);
    }
}
