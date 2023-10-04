using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Factories.CreatorInterface;

public interface IAppointment
{
    Task<Core.AggregatesModel.AppointmentAggregate.Appointment> Create(DateTime startTime,
        Guid doctorId,
        Guid patientId,
        int durationTime);
}
