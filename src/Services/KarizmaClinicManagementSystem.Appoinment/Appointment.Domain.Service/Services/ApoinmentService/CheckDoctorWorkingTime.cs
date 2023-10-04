using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Service.Services.ApoinmentService;

public class CheckDoctorWorkingTime : ICheckDoctorWorkingTime
{
    private readonly IDoctorRepository doctorRepository;

    public CheckDoctorWorkingTime(IDoctorRepository doctorRepository)
    {
        this.doctorRepository = doctorRepository;
    }
    public bool IsValid(Guid doctorId, DateTime startDate, DateTime endDate)
    {
        var doctor = doctorRepository.GetById(doctorId);

        CommonValidation.CheckNotNull(doctor, ErrorCode.IsNull(nameof(doctor)));

        DayOfWeek dayOfWeek = startDate.DayOfWeek;

        DailySchedule? availabeDate = doctor.WeeklySchedule.FirstOrDefault(a => a.Date.DayOfWeek == dayOfWeek);

        if (availabeDate is not null)
        {
            if (IsAvailableTime(startDate, endDate, availabeDate)) 
                return true;
            else 
                return false;
        }

        return false;
    }

    private bool IsAvailableTime(DateTime startDate, DateTime endDate, DailySchedule? availabeDate)
    {
        return startDate.TimeOfDay >= availabeDate.StartTime &&
            endDate.TimeOfDay <= availabeDate.EndTime;
    }
}
