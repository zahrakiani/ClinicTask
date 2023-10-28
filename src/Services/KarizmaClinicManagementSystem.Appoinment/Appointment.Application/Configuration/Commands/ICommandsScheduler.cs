using Appointment.Application.Contracts;

namespace Appointment.Application.Configuration.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(ICommand command);
}