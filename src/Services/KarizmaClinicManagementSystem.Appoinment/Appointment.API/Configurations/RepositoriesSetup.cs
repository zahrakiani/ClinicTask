using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Infrastructure.DomainEventsDispatching;
using Appointment.Infrastructure.Outbox;
using Appointment.Infrastructure.Persistence.Repositories;
using KarizmaClinicManagementSystem.Framework.Outbox;
//using Appointment.Infrastructure.Persistence.Repositories;

namespace Appointment.API.Configurations;

public static class RepositoriesSetup
{
    public static void AddRepositoriesSetup(this IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IDoctorTypeRepository, DoctorTypeRepository>();
        services.AddScoped<IClinicRepository, ClinicRepository>();

    }
}
