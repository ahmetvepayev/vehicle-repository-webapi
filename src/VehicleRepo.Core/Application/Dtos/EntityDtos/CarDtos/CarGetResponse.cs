namespace VehicleRepo.Core.Application.Dtos.EntityDtos.CarDtos;

public class CarGetResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public bool HeadlightsAreOn { get; set; }
}