using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Rules;
using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate.Rules;
using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Core.AggregatesModel.DoctorAggregate;

public class DailySchedule:Entity
{
    public Guid Id { get; private set; }
    public DoctorId DoctorId { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public DailySchedule()
    {

    }
    private DailySchedule(DoctorId doctorId, 
        DateTime date, 
        TimeSpan startTime,
        TimeSpan endTime,
        ICheckDoctorDailyScheduleIsInClinicWorkingHours checkDoctorDailyScheduleIsInClinicWorkingHours
        )
    {
        this.CheckRule(new DoctorDailyScheduleMustBeInClinicWorkingHoursRule(
                date, 
                startTime, 
                endTime,
                checkDoctorDailyScheduleIsInClinicWorkingHours));

        DoctorId = doctorId;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
    }

    public static DailySchedule CreateNew(DoctorId doctorId, 
        DateTime date,
        TimeSpan startTime,
        TimeSpan endTime,
        ICheckDoctorDailyScheduleIsInClinicWorkingHours checkDoctorDailyScheduleIsInClinicWorkingHours)
    {
        return new DailySchedule(doctorId, 
            date, 
            startTime, 
            endTime,
            checkDoctorDailyScheduleIsInClinicWorkingHours);
    }
}