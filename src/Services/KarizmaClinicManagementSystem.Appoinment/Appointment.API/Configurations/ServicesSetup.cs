using Appointment.Application.Configuration.Commands;
using Appointment.Domain.Core.Interfaces;
using Appointment.Infrastructure.Persistence;
using Appointment.Infrastructure.Processing.InternalCommands;
using KarizmaClinicManagementSystem.Framework.Abstracts;
using KarizmaClinicManagementSystem.Framework.Outbox;

namespace Appointment.API.Configurations;

public static class ServicesSetup
{
    public static void AddServicesSetup(this IServiceCollection services)
    {
        //UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();


    }
}
