using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Core.AggregatesModel.DoctorAggregate.Rules;

public class DoctorDailyScheduleMustBeInClinicWorkingHoursRule : IBusinessRule
{
    private readonly DateTime date;
    private readonly TimeSpan startTime;
    private readonly TimeSpan endTime;
    private readonly ICheckDoctorDailyScheduleIsInClinicWorkingHours doctorDailyScheduleIsInClinicWorkingHours;

    public string Code => ErrorCode.OutsideOfClinicHours.Code;
    public string Message => ErrorCode.OutsideOfClinicHours.Message;
    public DoctorDailyScheduleMustBeInClinicWorkingHoursRule(DateTime date,
        TimeSpan startTime, 
        TimeSpan endTime,
        ICheckDoctorDailyScheduleIsInClinicWorkingHours doctorDailyScheduleIsInClinicWorkingHours)
    {
        CommonValidation.CheckNotNull(date, ErrorCode.IsNull(nameof(date)));
        CommonValidation.CheckNotNull(startTime, ErrorCode.IsNull(nameof(startTime)));
        CommonValidation.CheckNotNull(endTime, ErrorCode.IsNull(nameof(endTime)));
        CommonValidation.CheckNotNull(doctorDailyScheduleIsInClinicWorkingHours, ErrorCode.IsNull(nameof(doctorDailyScheduleIsInClinicWorkingHours)));
        this.date = date;
        this.startTime = startTime;
        this.endTime = endTime;
        this.doctorDailyScheduleIsInClinicWorkingHours = doctorDailyScheduleIsInClinicWorkingHours;
    }
    public bool IsBroken()
    {
        var result = !doctorDailyScheduleIsInClinicWorkingHours.IsValid(date,startTime,endTime);
        return result;
    }
}
