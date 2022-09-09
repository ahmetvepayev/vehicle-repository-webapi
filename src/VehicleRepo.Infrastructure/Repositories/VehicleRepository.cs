using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Infrastructure.Database;

namespace VehicleRepo.Infrastructure.Repositories;

public class VehicleRepository : GenericEntityRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context)
    {
        
    }
}