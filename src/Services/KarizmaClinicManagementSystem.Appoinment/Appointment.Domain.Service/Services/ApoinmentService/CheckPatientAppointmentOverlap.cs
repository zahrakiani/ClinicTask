using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Utility;

namespace Appointment.Domain.Service.Services.ApoinmentService;

public class CheckPatientAppointmentOverlap : ICheckPatientAppointmentOverlap
{
    private readonly IPatientRepository patientRepository;

    public CheckPatientAppointmentOverlap(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }
    public bool IsValid(Guid patientId, DateTime startDate, DateTime endDate)
    {
        var appointments = patientRepository.GetAppointmentsOfPatientByDateAsync(patientId, DateOnly.FromDateTime(startDate));
        if (appointments is null) return true;
        if (appointments.Result.Any(x=> x.AppointmentTime.CheckOverlapTime(startDate,endDate)))
        {
            return false;
        }
       return true;
    }
}
