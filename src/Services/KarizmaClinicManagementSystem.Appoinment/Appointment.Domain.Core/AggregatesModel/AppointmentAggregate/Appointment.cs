using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Rules;
using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Services.ApoinmentService;
using KarizmaClinicManagementSystem.Framework.BaseModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;

public class Appointment : AggregateRoot<AppointmentId>
{

    public DateTime CreatedDate { get; private set; }
    public AppointmentTime AppointmentTime { get; private set; }
    public DoctorId DoctorId { get; private set; }
    public PatientId PatientId { get; private set; }
    public string Room { get; private set; }
    public IDoctorRepository DoctorRepository { get; }

    public Appointment()
    {

    }
    private Appointment(
    AppointmentId id,
    DoctorId doctorId,
    PatientId patientId,
    DateTime startDate,
    TimeSpan durationTime,
    string room)
    {
        Id = id;
        CreatedDate = DateTime.Now;
        DoctorId = doctorId;
        PatientId = patientId;
        AppointmentTime = AppointmentTime.CreateNew(startDate, durationTime);
        Room = room;
    }
    private Appointment(
        AppointmentId id,
        DoctorId doctorId,
        PatientId patientId,
        DateTime startDate,
        TimeSpan durationTime,
        IClinicRepository clinicRepository,
        IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository,        
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository)
    {
        Id = id;
        CreatedDate = DateTime.Now;
        DoctorId = doctorId;
        PatientId = patientId;
        AppointmentTime = AppointmentTime.CreateNew(startDate, durationTime);

        this.CheckRule(new AppointmentMustBeInClinicWorkingHoursRule(
                AppointmentTime,
                clinicRepository));

        this.CheckRule(new AppointmentMustBeInDoctorWorkingHoursRule(
               doctorId.Value,
               AppointmentTime,
               doctorRepository));

        this.CheckRule(new AppointmentDurationMustHaveValidDurationRule(
               doctorId.Value,
               AppointmentTime.DurationTime,
               doctorRepository,
               doctorTypeRepository));

        this.CheckRule(new AppointmentMustNotHaveMoreThanMaxAppointmentPerDayRule(
              patientId.Value,
              AppointmentTime,
              patientRepository));

        this.CheckRule(new AppointmentMustNotHaveOverlapForPatientRule(
              patientId.Value,
              AppointmentTime,
              patientRepository));

        this.CheckRule(new AppointmentMustHaveLimitedOverlapForDoctorRule(
              doctorId.Value,
              AppointmentTime,
              doctorRepository,
              doctorTypeRepository));

    }
    public static Appointment CreateNew(DoctorId doctorId, 
        PatientId patientId, 
        DateTime startDate, 
        TimeSpan durationTime, 
        IClinicRepository clinicRepository, 
        IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository,        
        IPatientRepository patientRepository, 
        IAppointmentRepository appointmentRepository)
    {
        var appointmentId = new AppointmentId(Guid.NewGuid());
        return new Appointment(appointmentId,
            doctorId,
            patientId,
            startDate,
            durationTime,
            clinicRepository, 
            doctorRepository,
            doctorTypeRepository,
            patientRepository,
            appointmentRepository);
    }

    public static Appointment SetRoom(AppointmentId appointmentId,
        DoctorId doctorId,
        PatientId patientId,
        DateTime startDate,
        TimeSpan durationTime,
        string roomName)
    {
        return new Appointment(appointmentId,
            doctorId,
            patientId,
            startDate,
            durationTime,
            roomName);
    }

}
