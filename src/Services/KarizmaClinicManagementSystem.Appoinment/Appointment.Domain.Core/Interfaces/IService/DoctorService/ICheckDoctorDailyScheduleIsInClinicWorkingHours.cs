using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Interfaces.IService.DoctorService;

public interface ICheckDoctorDailyScheduleIsInClinicWorkingHours
{
    bool IsValid(DateTime date, TimeSpan startTime, TimeSpan endTime);
}
