using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Services.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Rules;

public class AppointmentDurationMustHaveValidDurationRule : IBusinessRule
{
    private readonly ICheckDoctorValidDuration checkDoctorValidDuration;
    private Guid doctorId;
    private TimeSpan durationTime;

    public string Code => ErrorCode.DurationTimeValidation.Code;
    public string Message => ErrorCode.DurationTimeValidation.Message;

    public AppointmentDurationMustHaveValidDurationRule(Guid doctorId, 
        TimeSpan durationTime, 
        IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository)
    {
        CommonValidation.CheckNotNull(doctorId, ErrorCode.IsNull(nameof(doctorId)));
        CommonValidation.CheckNotNull(durationTime, ErrorCode.IsNull(nameof(durationTime)));
        CommonValidation.CheckNotNull(doctorRepository, ErrorCode.IsNull(nameof(doctorRepository)));
        CommonValidation.CheckNotNull(doctorTypeRepository, ErrorCode.IsNull(nameof(doctorTypeRepository)));

        this.doctorId = doctorId;
        this.durationTime = durationTime;
        this.checkDoctorValidDuration = new CheckDoctorValidDuration(doctorRepository,doctorTypeRepository);
    }

    public bool IsBroken()
    {
        var result = !checkDoctorValidDuration.IsValid(doctorId,durationTime);
        return result;
    }
}
