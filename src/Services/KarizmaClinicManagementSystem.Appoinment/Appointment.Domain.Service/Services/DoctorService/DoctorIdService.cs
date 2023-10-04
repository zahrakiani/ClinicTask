using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Services.DoctorService;

public static class DoctorIdService
{
    public static DoctorId GenerateNewDoctorId()
    => new DoctorId(Guid.NewGuid());

    public static DoctorId ConvertToDoctorId(this Guid guid)
    => new DoctorId(guid);

}
