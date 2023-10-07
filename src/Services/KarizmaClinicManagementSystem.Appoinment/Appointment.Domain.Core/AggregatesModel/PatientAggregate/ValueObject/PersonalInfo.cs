using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.PatientAggregate.ValueObject;

public class PersonalInfo : ValueObject<PersonalInfo>
{
    public string NationalCode { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public override string ToString()
    {
        return  FirstName + "" + LastName;
    }
}
