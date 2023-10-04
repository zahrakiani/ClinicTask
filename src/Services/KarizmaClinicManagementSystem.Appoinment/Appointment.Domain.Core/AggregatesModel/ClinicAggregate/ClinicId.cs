using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.ClinicAggregate;

public class ClinicId : StronglyTypedId<ClinicId>
{
    public ClinicId(Guid value) : base(value)
    {
    }
}
