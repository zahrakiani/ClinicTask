using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Events;

public class AddAppointmentSendNotificationEvent : DomainEventBase
{
    public Guid AppointmentId { get; }
    public  Guid DoctorId { get; }
    public  Guid PatientId { get; }

    public AddAppointmentSendNotificationEvent(Guid appointmentId,Guid doctorId, Guid patientId)
    {
        this.AppointmentId = appointmentId;
        this.DoctorId = doctorId;
        this.PatientId = patientId;
    }
}
