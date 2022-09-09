using VehicleRepo.Core.Domain.Interfaces;

namespace VehicleRepo.Core.Domain.Entities;

public class Vehicle : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}