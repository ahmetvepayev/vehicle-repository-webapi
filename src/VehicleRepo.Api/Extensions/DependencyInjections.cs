using Microsoft.EntityFrameworkCore;
using VehicleRepo.Core.Domain.Interfaces;
using VehicleRepo.Core.Domain.Interfaces.Repositories;
using VehicleRepo.Infrastructure.Database;
using VehicleRepo.Infrastructure.Database.Seed;
using VehicleRepo.Infrastructure.Repositories;

namespace VehicleRepo.Api.Extensions;

public static class DependencyInjections
{
    public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql(config.GetConnectionString("NpgCon"), action => {
                action.MigrationsAssembly("VehicleRepo.Infrastructure");
            });
        });

        services.AddScoped<DatabaseSeeder>();
        
        return services;
    }
}