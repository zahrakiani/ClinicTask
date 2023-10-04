using Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithSpecifiedTime;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Appointment.Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(CreateAppointmentWithSpecificTimeRequestValidator).Assembly;
        return services
            .AddValidatorsFromAssemblyContaining<CreateAppointmentWithSpecificTimeRequestValidator>()
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(assembly));

    }
}
