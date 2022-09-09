using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class BusService : PersistingServiceBase, IBusService
{
    private readonly IBusRepository _busRepository;

    public BusService(IUnitOfWork unitOfWork, IBusRepository busRepository) : base(unitOfWork)
    {
        _busRepository = busRepository;
    }

    public void Add(Bus bus)
    {
        _busRepository.Add(bus);

        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        var deletedBus = _busRepository.GetById(id);
        _busRepository.Delete(deletedBus);

        _unitOfWork.SaveChanges();
    }

    public List<Bus> GetAll()
    {
        return _busRepository.GetAll();
    }

    public List<Bus> GetAllByColor(string color)
    {
        return _busRepository.FindAll(b => b.Color == color);
    }

    public Bus GetById(int id)
    {
        return _busRepository.GetById(id);
    }
}
