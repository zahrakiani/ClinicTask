using Appointment.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Configurations;

public static class DatabaseSetup
{
    public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        string connString = configuration.GetConnectionString("ClinicDbContext");

        services.AddDbContext<AppointmentDbContext>(options =>
        {
            options.UseSqlServer(connString,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            });
        });
    }
}
