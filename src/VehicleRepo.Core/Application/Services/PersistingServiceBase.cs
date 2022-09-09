using VehicleRepo.Core.Domain.Interfaces;

namespace VehicleRepo.Core.Application.Services;

public class PersistingServiceBase
{
    protected readonly IUnitOfWork _unitOfWork;

    public PersistingServiceBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}