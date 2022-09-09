using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class VehicleService : PersistingServiceBase, IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository) : base(unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
    }

    public void Delete(int id)
    {
        var deletedVehicle = _vehicleRepository.GetById(id);
        _vehicleRepository.Delete(deletedVehicle);

        _unitOfWork.SaveChanges();
    }

    public List<Vehicle> GetAll()
    {
        return _vehicleRepository.GetAll();
    }

    public Vehicle GetById(int id)
    {
        return _vehicleRepository.GetById(id);
    }
}
