using AutoMapper;
using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.VehicleDtos;
using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Constants;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Utility.Extensions;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class VehicleService : PersistingServiceBase, IVehicleService
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository, IMapper mapper) : base(unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public StatusResponse Delete(int id)
    {
        int code;
        var deletedEntry = _vehicleRepository.GetById(id);

        if (deletedEntry == null)
        {
            code = 404;
            return new StatusResponse(code);
        }

        _vehicleRepository.Delete(deletedEntry);

        try
        {
            if (_unitOfWork.SaveChanges() == 0)
            {
                code = 500;
                List<string> errors = new(){
                    "The database responded with an error"
                };
                return new StatusResponse(code, errors);
            }
        }
        catch(Exception ex)
        {
            code = 500;
            List<string> errors = new(){
                "The database responded with an error"
            };
            return new StatusResponse(code, errors);
        }

        code = 200;
        return new StatusResponse(code);
    }

    public ObjectResponse<List<VehicleGetResponse>> GetAll()
    {
        int code;
        var rawData = _vehicleRepository.GetAll();

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<VehicleGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<VehicleGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<VehicleGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<List<VehicleGetResponse>> GetAllByColor(string color)
    {
        int code;
        color = color.ToLower();

        if(!VehicleConstants.VehicleColors.Contains(color))
        {
            code = 404;
            return new ObjectResponse<List<VehicleGetResponse>>(code);
        }

        var rawData = _vehicleRepository.FindAll(c => c.Color == color);

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<VehicleGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<VehicleGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<VehicleGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<VehicleGetResponse> GetById(int id)
    {
        int code;
        var rawData = _vehicleRepository.GetById(id);

        if (rawData == null)
        {
            code = 404;
            return new ObjectResponse<VehicleGetResponse>(code);
        }

        code = 200;
        var data = _mapper.Map<VehicleGetResponse>(rawData);
        var response = new ObjectResponse<VehicleGetResponse>(data, code);
        return response;
    }
}
