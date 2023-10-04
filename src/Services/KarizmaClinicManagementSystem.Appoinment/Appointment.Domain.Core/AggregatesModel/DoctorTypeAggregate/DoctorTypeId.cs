using KarizmaClinicManagementSystem.Framework.Abstracts;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;

public class DoctorTypeId : StronglyTypedId<DoctorTypeId>
{
    public DoctorTypeId(Guid value) : base(value)
    {
    }
}
