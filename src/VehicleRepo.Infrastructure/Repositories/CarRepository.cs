using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Infrastructure.Database;

namespace VehicleRepo.Infrastructure.Repositories;

public class CarRepository : GenericEntityRepository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
        
    }
}