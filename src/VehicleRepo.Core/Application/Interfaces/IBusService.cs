using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BusDtos;

namespace VehicleRepo.Core.Application.Interfaces;

public interface IBusService
{
    ObjectResponse<List<BusGetResponse>> GetAll();
    ObjectResponse<BusGetResponse> GetById(int id);
    ObjectResponse<List<BusGetResponse>> GetAllByColor(string color);
    StatusResponse Add(BusAddRequest request);
    StatusResponse Delete(int id);
}