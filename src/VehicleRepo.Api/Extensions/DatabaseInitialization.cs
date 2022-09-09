using VehicleRepo.Infrastructure.Database.Seed;

namespace VehicleRepo.Api.Extensions;

public static class DatabaseInitialization
{
    public static void InitializeDatabase(this WebApplication app)
    {
        using(var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();

            initializer.Initialize();
        }
    }
}