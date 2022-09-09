using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Infrastructure.Database;

namespace VehicleRepo.Infrastructure.Repositories;

public class BusRepository : GenericEntityRepository<Bus>, IBusRepository
{
    public BusRepository(AppDbContext context) : base(context)
    {
        
    }
}