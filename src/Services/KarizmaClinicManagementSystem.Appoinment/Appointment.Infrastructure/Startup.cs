using Appointment.Application.Configuration.Commands;
using Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithSpecifiedTime;
using Appointment.Infrastructure.DomainEventsDispatching;
using Appointment.Infrastructure.Emails;
using Appointment.Infrastructure.Outbox;
using Appointment.Infrastructure.Persistence;
using Appointment.Infrastructure.Processing.InternalCommands;
using FluentValidation;
using KarizmaClinicManagementSystem.Framework.Abstracts;
using KarizmaClinicManagementSystem.Framework.Notifications.Email;
using KarizmaClinicManagementSystem.Framework.Outbox;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var assembly = typeof(DomainEventsDispatcher).Assembly;
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<ICommandsScheduler, CommandsScheduler>();
        services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory("Data Source=.;Initial Catalog=ClinicManagmentSystem;Encrypt=False;User Id=sa;Password=123456"));
        services.AddScoped<IDomainEventsAccessor, DomainEventsAccessor>();
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
        services.AddScoped<IOutbox, OutboxAccessor>();
        return services
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(assembly));
    }
}
