using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;

namespace Appointment.Domain.Core.Factories.CreatorInterface;

public abstract class AppointmentFactory
{
    public abstract IAppointment GetAppointment();

}
