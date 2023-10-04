using Appointment.Domain.Core.Interfaces;
using Appointment.Infrastructure.Persistence;

namespace Appointment.API.Configurations;

public static class ServicesSetup
{
    public static void AddServicesSetup(this IServiceCollection services)
    {
        //UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
