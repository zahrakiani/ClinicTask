using Appointment.Domain.Core.AggregatesModel.ClinicAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Utility;

namespace Appointment.Domain.Service.Services.ApoinmentService;

public class CheckClinicWorkingTime : ICheckClinicWorkingTime
{
    private readonly IClinicRepository ClinicRepository;
    public CheckClinicWorkingTime(IClinicRepository clinicRepository)
    {
        ClinicRepository = clinicRepository;
    }
    public bool IsValid(DateTime startDate, DateTime endDate)
    {
        var clinic = ClinicRepository.GetMainClinic();
        List<DayOfWeek> workingDays = DateTimeUtility.GetDaysBetween(clinic.StartDay, clinic.EndDay);

        bool isAppointmentInWorkingDay = workingDays.Contains(startDate.DayOfWeek);
        bool isAppointmentInWorkingTime = CheckAppointmentInWorkingTime(clinic, startDate, endDate);
        if (isAppointmentInWorkingDay && isAppointmentInWorkingTime) return true;

        return false;
    }

    private bool CheckAppointmentInWorkingTime(Clinic clinic, DateTime startDate, DateTime endDate)
    {
        return startDate.TimeOfDay >= clinic.StartTime && endDate.TimeOfDay <= clinic.EndTime;
    }

}
