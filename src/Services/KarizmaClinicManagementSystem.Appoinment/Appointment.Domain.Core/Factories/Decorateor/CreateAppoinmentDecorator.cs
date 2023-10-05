using Appointment.Domain.Core.Factories.CreatorInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Factories.Decorateor;

public abstract class CreateAppoinmentDecorator : IAppointment
{
    private readonly IAppointment appointment;

    public CreateAppoinmentDecorator(IAppointment appointment)
    {
        this.appointment = appointment;
    }
    public virtual Task<AggregatesModel.AppointmentAggregate.Appointment> Create()
    {
        return appointment.Create();
    }
}
