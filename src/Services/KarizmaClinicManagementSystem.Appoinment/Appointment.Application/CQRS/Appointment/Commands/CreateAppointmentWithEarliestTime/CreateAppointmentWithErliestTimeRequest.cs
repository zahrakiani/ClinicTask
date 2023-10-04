using Appointment.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithEarliestTime;

public class AppointmentWithSpecificTimeAndDurationRequest : IRequest<CreatedAppointmentDto>
{
    [DefaultValue("6249f3e0-b7f2-411c-ad77-71de3c2417f0")]
    public Guid DoctorId { get; set; }

    [DefaultValue("8fce7d4f-2607-4588-8211-373b21850844")]
    public Guid PatientId { get; set; }

    [DefaultValue("10")]
    public int DurationMinutes { get; set; }

}
