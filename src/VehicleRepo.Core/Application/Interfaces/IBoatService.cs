using VehicleRepo.Core.Application.Dtos.ApiModelWrappers;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BoatDtos;

namespace VehicleRepo.Core.Application.Interfaces;

public interface IBoatService
{
    ObjectResponse<List<BoatGetResponse>> GetAll();
    ObjectResponse<BoatGetResponse> GetById(int id);
    ObjectResponse<List<BoatGetResponse>> GetAllByColor(string color);
    StatusResponse Add(BoatAddRequest request);
    StatusResponse Delete(int id);
}