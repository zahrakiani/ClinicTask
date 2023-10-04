using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Rules;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using System.ComponentModel.DataAnnotations;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;

public class AppointmentTime : ValueObject<AppointmentTime>
{
    public DateTime StartTime { get; private set; }
    public TimeSpan DurationTime { get; private set; }
    public DateTime EndTime
    {
        get
        {
            return StartTime + DurationTime;
        }
        private set { }
    }
    private AppointmentTime(DateTime startTime, TimeSpan durationTime)
    {
        StartTime = startTime;
        DurationTime = durationTime;
        EndTime = EndTime;
        CommonValidation.CheckCondition(startTime <= EndTime , ErrorCode.StartTimeSmallerValidation);
        CommonValidation.CheckCondition(startTime >= DateTime.Now, ErrorCode.StartTimeValidation);
        CommonValidation.CheckCondition(durationTime.TotalMinutes > 0, ErrorCode.DurationTimeValidation);
        

    }

    public static AppointmentTime CreateNew(DateTime startTime, TimeSpan durationTime)
    {
        return new AppointmentTime(startTime, durationTime);
    }

}