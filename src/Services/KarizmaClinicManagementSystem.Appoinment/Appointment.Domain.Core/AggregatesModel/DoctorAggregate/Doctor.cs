using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate.ValueObjects;
using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.DoctorAggregate;

public class Doctor : AggregateRoot<DoctorId>
{
    public PersonalInfo Info { get; private set; }
    public DoctorTypeId DoctorTypeId { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string Mobile { get; private set; } = string.Empty;
    public List<DailySchedule> WeeklySchedule { get; private set; }

    private readonly List<AppointmentAggregate.Appointment> appointments = new List<AppointmentAggregate.Appointment>();
    public IReadOnlyList<AppointmentAggregate.Appointment> Appointments => appointments;
    public Doctor()
    {

    }

    private Doctor(DoctorId id,
        string prefix,
        string firstName, 
        string lastName, 
        DoctorTypeId doctorTypeId, 
        string email, 
        string mobile)
    {
        Id = id;
        DoctorTypeId = doctorTypeId;
        Email = email;
        Mobile = mobile;
        BuildPersonalInfo(prefix,firstName, lastName);
    }

    private PersonalInfo BuildPersonalInfo(string prefix, string firstName, string lastName)
    {
        return PersonalInfo.CreateNew(prefix, firstName, lastName);
    }
    public static Doctor CreateNew(string prefix, string firstName, string lastName, DoctorTypeId doctorTypeId, string email, string mobile)
    {
        var doctorId = new DoctorId(Guid.NewGuid());
        return new Doctor(doctorId, prefix, firstName, lastName, doctorTypeId, email, mobile);
    }
    public DailySchedule BuildDailySchedule(DoctorId doctorId, 
        DateTime date, 
        TimeSpan startTime, 
        TimeSpan endTime,
        ICheckDoctorDailyScheduleIsInClinicWorkingHours checkDoctorDailyScheduleIsInClinicWorkingHours)
    {
        return DailySchedule.CreateNew(doctorId, 
            date, 
            startTime, 
            endTime, 
            checkDoctorDailyScheduleIsInClinicWorkingHours);
    }
}
