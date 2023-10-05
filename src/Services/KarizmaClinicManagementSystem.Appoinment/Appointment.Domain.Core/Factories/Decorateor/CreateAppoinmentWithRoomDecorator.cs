using Appointment.Domain.Core.Factories.CreatorInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Factories.Decorateor;

public class CreateAppoinmentWithRoomDecorator : CreateAppoinmentDecorator
{
    public CreateAppoinmentWithRoomDecorator(IAppointment appointment) : base(appointment)
    {
    }

    public override async Task<AggregatesModel.AppointmentAggregate.Appointment> Create()
    {
        var appointment = await base.Create();
        //Write Logging Here
        return appointment;
    }

}
