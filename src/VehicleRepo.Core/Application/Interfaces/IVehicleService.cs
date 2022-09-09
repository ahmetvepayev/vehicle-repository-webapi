using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.VehicleDtos;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Interfaces;

public interface IVehicleService
{
    ObjectResponse<List<VehicleGetResponse>> GetAll();
    ObjectResponse<VehicleGetResponse> GetById(int id);
    ObjectResponse<List<VehicleGetResponse>> GetAllByColor(string color);
    StatusResponse Delete(int id);
}