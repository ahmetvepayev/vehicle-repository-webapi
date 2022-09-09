using VehicleRepo.Core.Application.Dtos.EntityDtos.BoatDtos;
using VehicleRepo.Core.Domain.Constants;

namespace VehicleRepo.Core.Application.DtoValidators;

public static class BoatValidators
{
    public static bool IsValid(this BoatAddRequest request, out List<string> errors)
    {
        errors = new();

        if(String.IsNullOrEmpty(request.Name))
        {
            errors.Add("Name is required");
        }

        if(String.IsNullOrEmpty(request.Color))
        {
            errors.Add("Color is required");
        }
        else if(!VehicleConstants.VehicleColors.Contains(request.Color = request.Color.ToLower()))
        {
            errors.Add("The chosen color is not defined or not allowed");
        }

        return !errors.Any();
    }
}