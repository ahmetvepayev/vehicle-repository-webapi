using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class CarService : PersistingServiceBase, ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(IUnitOfWork unitOfWork, ICarRepository carRepository) : base(unitOfWork)
    {
        _carRepository = carRepository;
    }

    public void Add(Car car)
    {
        _carRepository.Add(car);

        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        var deletedCar = _carRepository.GetById(id);
        _carRepository.Delete(deletedCar);

        _unitOfWork.SaveChanges();
    }

    public List<Car> GetAll()
    {
        return _carRepository.GetAll();
    }

    public Car GetById(int id)
    {
        return _carRepository.GetById(id);
    }

    public void SwitchHeadlights(int id, string headlights)
    {
        var alteredCar = _carRepository.GetById(id);
        alteredCar.HeadlightsAreOn = (headlights == "on");

        _unitOfWork.SaveChanges();
    }
}