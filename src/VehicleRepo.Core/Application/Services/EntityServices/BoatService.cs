using AutoMapper;
using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BoatDtos;
using VehicleRepo.Core.Application.DtoValidators;
using VehicleRepo.Core.Application.Interfaces;
using VehicleRepo.Core.Domain.Constants;
using VehicleRepo.Core.Domain.Entities;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Utility.Extensions;

namespace VehicleRepo.Core.Application.Services.EntityServices;

public class BoatService : PersistingServiceBase, IBoatService
{
    private readonly IMapper _mapper;
    private readonly IBoatRepository _boatRepository;

    public BoatService(IUnitOfWork unitOfWork, IBoatRepository boatRepository, IMapper mapper) : base(unitOfWork)
    {
        _boatRepository = boatRepository;
        _mapper = mapper;
    }

    public StatusResponse Add(BoatAddRequest request)
    {
        int code;
        List<string> errors;
        
        if (!request.IsValid(out errors))
        {
            code = 400;
            return new StatusResponse(code, errors);
        }

        var addedEntry = _mapper.Map<Boat>(request);
        _boatRepository.Add(addedEntry);

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
        var deletedEntry = _boatRepository.GetById(id);

        if (deletedEntry == null)
        {
            code = 404;
            return new StatusResponse(code);
        }

        _boatRepository.Delete(deletedEntry);

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

    public ObjectResponse<List<BoatGetResponse>> GetAll()
    {
        int code;
        var rawData = _boatRepository.GetAll();

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<BoatGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<BoatGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<BoatGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<List<BoatGetResponse>> GetAllByColor(string color)
    {
        int code;
        color = color.ToLower();

        if(!VehicleConstants.VehicleColors.Contains(color))
        {
            code = 404;
            return new ObjectResponse<List<BoatGetResponse>>(code);
        }

        var rawData = _boatRepository.FindAll(c => c.Color == color);

        if (rawData.IsNullOrEmpty())
        {
            code = 404;
            return new ObjectResponse<List<BoatGetResponse>>(code);
        }

        code = 200;
        var data = rawData.Select(x => _mapper.Map<BoatGetResponse>(x)).OrderBy(x => x.Id).ToList();
        var response = new ObjectResponse<List<BoatGetResponse>>(data, code);
        return response;
    }

    public ObjectResponse<BoatGetResponse> GetById(int id)
    {
        int code;
        var rawData = _boatRepository.GetById(id);

        if (rawData == null)
        {
            code = 404;
            return new ObjectResponse<BoatGetResponse>(code);
        }

        code = 200;
        var data = _mapper.Map<BoatGetResponse>(rawData);
        var response = new ObjectResponse<BoatGetResponse>(data, code);
        return response;
    }
}
