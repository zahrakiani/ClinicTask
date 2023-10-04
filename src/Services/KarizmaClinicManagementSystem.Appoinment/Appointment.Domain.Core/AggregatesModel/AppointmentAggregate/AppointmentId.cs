using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;

public class AppointmentId : StronglyTypedId<AppointmentId>
{    public AppointmentId(Guid value) : base(value)
    {
    }
}
