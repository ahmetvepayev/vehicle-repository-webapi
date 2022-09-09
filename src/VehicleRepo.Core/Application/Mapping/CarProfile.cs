using AutoMapper;
using VehicleRepo.Core.Application.Dtos.EntityDtos.CarDtos;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Mapping;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarGetResponse>();
        CreateMap<CarAddRequest, Car>();
    }
}