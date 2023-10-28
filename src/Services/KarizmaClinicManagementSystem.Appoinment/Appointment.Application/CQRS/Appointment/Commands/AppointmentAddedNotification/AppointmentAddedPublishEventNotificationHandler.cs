//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Appointment.Application.CQRS.Appointment.Commands.AppointmentAddedNotification;
//using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Events;

//using MediatR;

//namespace CompanyName.MyMeetings.Modules.Meetings.Application.Meetings.SendMeetingAttendeeAddedEmail
//{
//    internal class AppointmentAddedPublishEventNotificationHandler : INotificationHandler<AppointmentAddedSendNotification>
//    {
//        private readonly IEventsBus _eventsBus;

//        internal AppointmentAddedPublishEventNotificationHandler(IEventsBus eventsBus)
//        {
//            _eventsBus = eventsBus;
//        }

//        public Task Handle(AppointmentAddedSendNotification notification, CancellationToken cancellationToken)
//        {
//            _eventsBus.Publish(new AddAppointmentSendNotificationEvent(
//                //Guid.NewGuid(),
//                //notification.DomainEvent.OccurredOn,
//                notification.DomainEvent.DoctorId,
//                notification.DomainEvent.PatientId,
//                notification.DomainEvent.AppointmentId));

//            return Task.CompletedTask;
//        }
//    }
//}