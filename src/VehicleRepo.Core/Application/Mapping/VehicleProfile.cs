using AutoMapper;
using VehicleRepo.Core.Application.Dtos.EntityDtos.VehicleDtos;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Core.Application.Mapping;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        CreateMap<Vehicle, VehicleGetResponse>()
            .ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src =>
                    src is Car ? nameof(Car) :
                    src is Bus ? nameof(Bus) :
                    src is Boat ? nameof(Boat) :
                    "NONE"
                )
            );
    }
}