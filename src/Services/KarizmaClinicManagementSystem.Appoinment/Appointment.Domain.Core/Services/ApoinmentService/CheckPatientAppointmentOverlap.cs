using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Utility;

namespace Appointment.Domain.Core.Services.ApoinmentService;

public class CheckPatientAppointmentOverlap : ICheckPatientAppointmentOverlap
{
    private readonly IPatientRepository patientRepository;

    public CheckPatientAppointmentOverlap(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }
    public bool IsValid(Guid patientId, DateTime startDate, DateTime endDate)
    {
        var appointments = patientRepository.GetAppointmentsOfPatientByDate(patientId, DateOnly.FromDateTime(startDate));
        if (appointments is null || appointments.Count == 0) return true;
        if (appointments.Any(x=> x.AppointmentTime.CheckOverlapTime(startDate,endDate)))
        {
            return false;
        }
       return true;
    }
}
