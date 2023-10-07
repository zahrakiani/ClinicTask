using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Infrastructure.Emails;
using Appointment.Infrastructure.Persistence.Repositories;
using KarizmaClinicManagementSystem.Framework.Notifications.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Appointment.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
        return services;
 }
}
