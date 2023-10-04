using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Dtos;

public class CreatedAppointmentDto
{
    public DoctorId DoctorId { get; set; }
    public PatientId PatientId { get; set; }
    public string Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan Duration { get; set; }
}
