using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Infrastructure.Database;

namespace VehicleRepo.Infrastructure.Repositories;

public class BoatRepository : GenericEntityRepository<Boat>, IBoatRepository
{
    public BoatRepository(AppDbContext context) : base(context)
    {
        
    }
}