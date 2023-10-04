using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using Appointment.Domain.Core.Factories.CreatorInterface;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;
using Appointment.Domain.Core.Services.DoctorService;
using Appointment.Domain.Core.Services.PatientService;

namespace Appointment.Domain.Core.Factories.ConcreteCreators;

public class AppointmentWithSpecificTimeAndDuration : IAppointment
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;
    private readonly IClinicRepository clinicRepository;
    private readonly IPatientRepository patientRepository;
    private readonly IAppointmentRepository appointmentRepository;
    private readonly Guid doctorId;
    private readonly Guid patientId;
    private readonly DateTime startTime;
    private readonly int duration;

    public AppointmentWithSpecificTimeAndDuration(IDoctorRepository doctorRepository, 
        IDoctorTypeRepository doctorTypeRepository,
        IClinicRepository clinicRepository,
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository,
        Guid doctorId,
        Guid patientId,
        DateTime startTime,
        int duration)
    {
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
        this.clinicRepository = clinicRepository;
        this.patientRepository = patientRepository;
        this.appointmentRepository = appointmentRepository;
        this.doctorId = doctorId;
        this.patientId = patientId;
        this.startTime = startTime;
        this.duration = duration;
    }
    public async Task<AppointmentEntity> Create()
    {
        TimeSpan durationTime = TimeSpan.FromMinutes(duration);
        AppointmentEntity appointment = AppointmentEntity.CreateNew(doctorId.ConvertToDoctorId(),
            patientId.ConvertToPatientId(),
            startTime,
            durationTime,
            clinicRepository,
            doctorRepository,
            doctorTypeRepository,
            patientRepository,
            appointmentRepository);

        return  appointment;
    }

}
