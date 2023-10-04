using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Services.PatientService;


public static class PatientIdService
{
    public static PatientId GenerateNewPatientId()
    => new PatientId(Guid.NewGuid());
    
    public static PatientId ConvertToPatientId(this Guid guid)
    => new PatientId(guid);
    
}
