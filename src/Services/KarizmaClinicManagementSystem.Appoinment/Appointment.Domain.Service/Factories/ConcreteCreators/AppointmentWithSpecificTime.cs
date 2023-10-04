using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using Appointment.Domain.Service.Factories.CreatorInterface;
using Appointment.Domain.Service.Core.ApoinmentService;
using Appointment.Domain.Service.Core.DoctorService;
using Appointment.Domain.Service.Core.PatientService;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;

namespace Appointment.Domain.Core.Factories.ConcreteCreators;

public class AppointmentWithSpecificTime : IAppointment
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;
    private readonly ICheckClinicWorkingTime checkClinicWorkingTime;
    private readonly ICheckDoctorWorkingTime checkDoctorWorkingTime;
    private readonly ICheckPatientMaxAppointmentPerDay checkPatientMaxAppointment;
    private readonly ICheckPatientAppointmentOverlap checkPatientAppointmentOverlap;
    private readonly ICheckDoctorAppointmentOverlapLimit checkDoctorAppointmentOverlapLimit;
    private readonly ICheckDoctorValidDuration checkDoctorValidDuration;

    public AppointmentWithSpecificTime(IDoctorRepository doctorRepository)
    {
        this.doctorRepository = doctorRepository;
    }

    public AppointmentWithSpecificTime(IDoctorRepository doctorRepository, 
        IDoctorTypeRepository doctorTypeRepository) : this(doctorRepository)
    {
        this.doctorTypeRepository = doctorTypeRepository;
    }

    public AppointmentWithSpecificTime(IDoctorRepository doctorRepository, 
        IDoctorTypeRepository doctorTypeRepository,
        ICheckClinicWorkingTime checkClinicWorkingTime,
        ICheckDoctorWorkingTime checkDoctorWorkingTime,
        ICheckPatientMaxAppointmentPerDay checkPatientMaxAppointment,
        ICheckPatientAppointmentOverlap checkPatientAppointmentOverlap,
        ICheckDoctorAppointmentOverlapLimit checkDoctorAppointmentOverlapLimit,
        ICheckDoctorValidDuration checkDoctorValidDuration)
    {
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
        this.checkClinicWorkingTime = checkClinicWorkingTime;
        this.checkDoctorWorkingTime = checkDoctorWorkingTime;
        this.checkPatientMaxAppointment = checkPatientMaxAppointment;
        this.checkPatientAppointmentOverlap = checkPatientAppointmentOverlap;
        this.checkDoctorAppointmentOverlapLimit = checkDoctorAppointmentOverlapLimit;
        this.checkDoctorValidDuration = checkDoctorValidDuration;
    }
    public async Task<AppointmentEntity> Create(
        DateTime startTime,
        Guid doctorId,
        Guid patientId,
        int durationTime
    )
    {
        TimeSpan maxDurationTime = await GetDurationTimeAsync(doctorId);
        AppointmentEntity appointment = new AppointmentEntity(AppointmentIdService.GenerateNewAppointmentId(),
            doctorId.ConvertToDoctorId(), 
            patientId.ConvertToPatientId(),
            startTime,
            maxDurationTime,
            checkClinicWorkingTime,
            checkDoctorWorkingTime,
            checkPatientMaxAppointment,
            checkPatientAppointmentOverlap,
            checkDoctorAppointmentOverlapLimit,
            checkDoctorValidDuration);

        return  appointment;
    }

    private async Task<TimeSpan> GetDurationTimeAsync(Guid doctorId)
    {
        var doctor = doctorRepository.GetById(doctorId);
        CommonValidation.CheckNotNull(doctor, ErrorCode.IsNull(nameof(doctor)));
        var doctorType = doctorTypeRepository.GetById(doctor.DoctorTypeId.Value);
        return doctorType.MaxDurationAppointmentTime;
    }
}
