using Appointment.Application.Events;
using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.CQRS.Appointment.Commands.AppointmentAddedNotification;

public class AppointmentAddedSendNotification : DomainNotificationBase<AddAppointmentSendNotificationEvent>
{
    public AppointmentAddedSendNotification(AddAppointmentSendNotificationEvent domainEvent, Guid id) 
        : base(domainEvent, id)
    {
    }
}
