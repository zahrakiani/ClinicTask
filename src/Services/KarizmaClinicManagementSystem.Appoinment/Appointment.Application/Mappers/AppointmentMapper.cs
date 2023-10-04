using Appointment.Application.Dtos;
using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Mappers;

public static class AppointmentMapper
{
    public static CreatedAppointmentDto MapToResultDto(this Domain.Core.AggregatesModel.AppointmentAggregate.Appointment appointment)
    {
        return new CreatedAppointmentDto
        {
            StartTime = TimeOnly.FromDateTime(appointment.AppointmentTime.StartTime).ToTimeSpan(),
            Duration = appointment.AppointmentTime.DurationTime,
            Day = appointment.AppointmentTime.StartTime.DayOfWeek.ToString(),
            DoctorId = appointment.DoctorId,
            PatientId = appointment.PatientId,
        };
    }
}
