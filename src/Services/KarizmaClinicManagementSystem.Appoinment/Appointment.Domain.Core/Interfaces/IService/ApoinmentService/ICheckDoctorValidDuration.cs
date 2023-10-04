using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Interfaces.IService.ApoinmentService;

public interface ICheckDoctorValidDuration
{
    bool IsValid(Guid doctorId,TimeSpan duration);
}
