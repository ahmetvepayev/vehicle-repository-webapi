using AutoMapper;
using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BusDtos;
using VehicleRepo.Core.Application.DtoValidators;
using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Constants;
using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Utility.Extensions;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class BusService : PersistingServiceBase, IBusService
{
    private readonly IMapper _mapper;
    private readonly IBusRepository _busRepository;

    public BusService(IUnitOfWork unitOfWork, IBusRepository busRepository, IMapper mapper) : base(unitOfWork)
    {
        _busRepository = busRepository;
        _mapper = mapper;
    }

    public StatusResponse Add(BusAddRequest request)
    {
        int code;
        List<string> errors;
        
        if (!request.IsValid(out errors))
        {
            code = 400;
            return new StatusResponse(code, errors);
        }

        var addedEntry = _mapper.Map<Bus>(request);
        _busRepository.Add(addedEntry);

        try
        {
            if (_unitOfWork.SaveChanges() == 0)
            {
                code = 400;
                errors = new(){
                    "Changes to the database did not persist"
                };
                return new StatusResponse(code, errors);
            }
        }
        catch(Exception ex)
        {
            code = 500;
            errors = new(){
                "The database responded with an error"
            };
            return new StatusResponse(code, errors);
        }

        code = 200;
        return new StatusResponse(code);
    }

    public StatusResponse Delete(int id)
    {
        int code;
        var deletedEntry = _busRepository.GetById(id);

        if (deletedEntry == null)
        {
            code = 404;
            return new StatusResponse(code);
        }

        _busRepository.Delete(deletedEntry);

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

    public ObjectResponse<List<BusGetResponse>> GetAll()
    {
        int code;
        var rawData = _busRepository.GetAll();

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<BusGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<BusGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<BusGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<List<BusGetResponse>> GetAllByColor(string color)
    {
        int code;
        color = color.ToLower();

        if(!VehicleConstants.VehicleColors.Contains(color))
        {
            code = 404;
            return new ObjectResponse<List<BusGetResponse>>(code);
        }

        var rawData = _busRepository.FindAll(c => c.Color == color);

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<BusGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<BusGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<BusGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<BusGetResponse> GetById(int id)
    {
        int code;
        var rawData = _busRepository.GetById(id);

        if (rawData == null)
        {
            code = 404;
            return new ObjectResponse<BusGetResponse>(code);
        }

        code = 200;
        var data = _mapper.Map<BusGetResponse>(rawData);
        var response = new ObjectResponse<BusGetResponse>(data, code);
        return response;
    }
}
