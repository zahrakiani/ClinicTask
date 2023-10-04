using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Core.Services.ApoinmentService;

public class CheckDoctorValidDuration : ICheckDoctorValidDuration
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;

    public CheckDoctorValidDuration(IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository)
    {
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
    }
    public bool IsValid(Guid doctorId, TimeSpan duration)
    {
        var doctor = doctorRepository.GetById(doctorId);
        CommonValidation.CheckNotNull(doctor, ErrorCode.IsNull(nameof(doctor)));
        var doctorType = doctorTypeRepository.GetById(doctor.DoctorTypeId.Value);
        return duration <= doctorType.MaxDurationAppointmentTime &&
            duration >= doctorType.MinDurationAppointmentTime;
    }
}
