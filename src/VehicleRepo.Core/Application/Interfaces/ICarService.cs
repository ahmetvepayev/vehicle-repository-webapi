using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.CarDtos;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Interfaces;

public interface ICarService
{
    ObjectResponse<List<CarGetResponse>> GetAll();
    ObjectResponse<CarGetResponse> GetById(int id);
    ObjectResponse<List<CarGetResponse>> GetAllByColor(string color);
    StatusResponse Add(CarAddRequest request);
    StatusResponse Delete(int id);
    StatusResponse SwitchHeadlights(int id, string headlights);
}