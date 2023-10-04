using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.DoctorAggregate;

public class DoctorId : StronglyTypedId<DoctorId>
{
    public DoctorId(Guid value) : base(value)
    {
    }
}
