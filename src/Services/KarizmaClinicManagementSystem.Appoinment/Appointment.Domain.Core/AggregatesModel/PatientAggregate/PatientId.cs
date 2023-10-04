using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.PatientAggregate;

public class PatientId : StronglyTypedId<PatientId>
{
    public PatientId(Guid value) : base(value)
    {
    }
}
