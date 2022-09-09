using Microsoft.EntityFrameworkCore;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Infrastructure.Database.Seed;

public class DatabaseSeeder
{
    private readonly AppDbContext _context;

    public DatabaseSeeder(AppDbContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();

        LoadVehicles();
    }

    private void LoadVehicles()
    {
        _context.Vehicles.AddRange(
            new Boat{
                // Id = 1
                Name = "Boat 1",
                Color = "red"
            },
            new Boat{
                // Id = 2
                Name = "Boat 2",
                Color = "blue"
            },
            new Bus{
                // Id = 3
                Name = "Bus 1",
                Color = "black"
            },
            new Bus{
                // Id = 4
                Name = "Bus 2",
                Color = "blue"
            },
            new Car{
                // Id = 5
                Name = "Car 1",
                Color = "white"
            },
            new Car{
                // Id = 6
                Name = "Car 2",
                Color = "black"
            }
        );

        _context.SaveChanges();
    }
}