using AutoMapper;
using VehicleRepo.Core.Application.Dtos.EntityDtos.BusDtos;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Mapping;

public class BusProfile : Profile
{
    public BusProfile()
    {
        CreateMap<Bus, BusGetResponse>();
        CreateMap<BusAddRequest, Bus>();
    }
}