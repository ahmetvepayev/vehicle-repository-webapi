using AutoMapper;
using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.CarDtos;
using VehicleRepo.Core.Application.DtoValidators;
using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Constants;
using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Utility.Extensions;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class CarService : PersistingServiceBase, ICarService
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;

    public CarService(IUnitOfWork unitOfWork, ICarRepository carRepository, IMapper mapper) : base(unitOfWork)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public StatusResponse Add(CarAddRequest request)
    {
        int code;
        List<string> errors;
        
        if (!request.IsValid(out errors))
        {
            code = 400;
            return new StatusResponse(code, errors);
        }

        var addedEntry = _mapper.Map<Car>(request);
        _carRepository.Add(addedEntry);

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
        var deletedEntry = _carRepository.GetById(id);

        if (deletedEntry == null)
        {
            code = 404;
            return new StatusResponse(code);
        }

        _carRepository.Delete(deletedEntry);

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

    public ObjectResponse<List<CarGetResponse>> GetAll()
    {
        int code;
        var rawData = _carRepository.GetAll();

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<CarGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<CarGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<CarGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<List<CarGetResponse>> GetAllByColor(string color)
    {
        int code;
        color = color.ToLower();

        if(!VehicleConstants.VehicleColors.Contains(color))
        {
            code = 404;
            return new ObjectResponse<List<CarGetResponse>>(code);
        }

        var rawData = _carRepository.FindAll(c => c.Color == color);

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<CarGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<CarGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<CarGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<CarGetResponse> GetById(int id)
    {
        int code;
        var rawData = _carRepository.GetById(id);

        if (rawData == null)
        {
            code = 404;
            return new ObjectResponse<CarGetResponse>(code);
        }

        code = 200;
        var data = _mapper.Map<CarGetResponse>(rawData);
        var response = new ObjectResponse<CarGetResponse>(data, code);
        return response;
    }

    public StatusResponse SwitchHeadlights(int id, string headlights)
    {
        int code;
        List<string> errors;

        var updatedEntry = _carRepository.GetById(id);
        if (updatedEntry == null)
        {
            code = 404;
            return new StatusResponse(code);
        }

        switch(headlights)
        {
            case "on":
                updatedEntry.HeadlightsAreOn = true;
                break;
            case "off":
                updatedEntry.HeadlightsAreOn = false;
                break;
            default:
                code = 400;
                errors = new(){
                    "Headlights can be either 'on' or 'off'"
                };
                return new StatusResponse(code, errors);;
        }

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
}
