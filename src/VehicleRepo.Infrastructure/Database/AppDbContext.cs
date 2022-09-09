using Microsoft.EntityFrameworkCore;
using VehicleRepo.Core.Domain.Entities;

namespace VehicleRepo.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Boat> Boats { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
    }
}