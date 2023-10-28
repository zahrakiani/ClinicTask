//using Appointment.Application.Configuration.Commands;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Appointment.Application.CQRS.Appointment.Commands.AppointmentAddedNotification;

//public class AppointmentAddedSendNotificationHandler : INotificationHandler<AppointmentAddedSendNotification>
//{
//    private readonly ICommandsScheduler commandsScheduler;

//    public AppointmentAddedSendNotificationHandler(ICommandsScheduler commandsScheduler)
//    {
//        this.commandsScheduler = commandsScheduler;
//    }
//    public async Task Handle(AppointmentAddedSendNotification notification, CancellationToken cancellationToken)
//    {
//        await commandsScheduler.EnqueueAsync(
//                new SendApointmentAddedEmailCommand(
//                    Guid.NewGuid(),
//                    notification.DomainEvent.AppointmentId,
//                    notification.DomainEvent.DoctorId,
//                    notification.DomainEvent.PatientId));
//    }
//}
