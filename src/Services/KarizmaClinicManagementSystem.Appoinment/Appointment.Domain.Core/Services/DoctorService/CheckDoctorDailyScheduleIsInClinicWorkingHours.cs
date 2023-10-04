using Appointment.Domain.Core.AggregatesModel.ClinicAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using Appointment.Domain.Core.Shared.Utility;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Core.Services.DoctorService;

public class CheckDoctorDailyScheduleIsInClinicWorkingHours : ICheckDoctorDailyScheduleIsInClinicWorkingHours
{
    private readonly IClinicRepository clinicRepository;

    public CheckDoctorDailyScheduleIsInClinicWorkingHours(IClinicRepository clinicRepository)
    {
        this.clinicRepository = clinicRepository;
    }
    public bool IsValid(DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
        var clinic = clinicRepository.GetMainClinic();
        CommonValidation.CheckNotNull(clinic, ErrorCode.IsNull(nameof(clinic)));
        var isValidDay = CheckValidDay(clinic, date);
        var isValidTime = CheckValidTime(clinic.StartTime,
            clinic.EndTime,
            startTime,
            endTime);
       return isValidDay && isValidTime;
    }

    private bool CheckValidTime(TimeSpan startTime, TimeSpan endTime, TimeSpan clinicStartTime, TimeSpan clinicEndTime)
    {
        return startTime >= clinicStartTime && endTime <= clinicEndTime;
    }

    private bool CheckValidDay(Clinic clinic, DateTime date)
    {
        var availDays = DateTimeUtility.GetDaysBetween(clinic.StartDay, clinic.EndDay);
        return availDays.Contains(date.DayOfWeek);
    }
}
