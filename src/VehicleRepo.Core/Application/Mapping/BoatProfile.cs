using AutoMapper;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BoatDtos;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Mapping;

public class BoatProfile : Profile
{
    public BoatProfile()
    {
        CreateMap<Boat, BoatGetResponse>();
        CreateMap<BoatAddRequest, Boat>();
    }
}