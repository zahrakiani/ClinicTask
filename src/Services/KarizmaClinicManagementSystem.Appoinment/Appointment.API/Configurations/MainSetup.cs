using Appointment.Domain.Core.Configurations;

namespace Appointment.API.Configurations;

public static class MainSetup
{
    public static void RegisterDI(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseSetup.AddDatabaseSetup(services, configuration);
        RepositoriesSetup.AddRepositoriesSetup(services);
        ServicesSetup.AddServicesSetup(services);
        DomainServicesSetup.AddServicesSetup(services);

    }
}
