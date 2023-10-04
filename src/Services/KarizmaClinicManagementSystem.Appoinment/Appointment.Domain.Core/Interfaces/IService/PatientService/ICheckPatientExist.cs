using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Interfaces.IService.PatientService;

public interface ICheckPatientExist
{
    bool IsValid(Guid patientId);
}
