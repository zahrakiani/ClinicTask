using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Services.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Rules;

public class AppointmentMustHaveLimitedOverlapForDoctorRule : IBusinessRule
{
    private readonly ICheckDoctorAppointmentOverlapLimit checkDoctorAppointmentOverlapLimit;
    private readonly Guid doctorId;
    private readonly AppointmentTime appointmentTime;

    public string Code => ErrorCode.OverlapWithDoctorAppointment.Code;
    public string Message => ErrorCode.OverlapWithDoctorAppointment.Message;

    public AppointmentMustHaveLimitedOverlapForDoctorRule(Guid doctorId, 
        AppointmentTime appointmentTime,
        IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository)
    {
        CommonValidation.CheckNotNull(doctorId, ErrorCode.IsNull(nameof(doctorId)));
        CommonValidation.CheckNotNull(appointmentTime, ErrorCode.IsNull(nameof(appointmentTime)));
        CommonValidation.CheckNotNull(doctorRepository, ErrorCode.IsNull(nameof(doctorRepository)));
        CommonValidation.CheckNotNull(doctorTypeRepository, ErrorCode.IsNull(nameof(doctorTypeRepository)));

        this.doctorId = doctorId;
        this.appointmentTime = appointmentTime;
        this.checkDoctorAppointmentOverlapLimit = new CheckDoctorAppointmentOverlapLimit(doctorRepository,doctorTypeRepository );
    }
    public void AdjustError(ErrorCode errorCode)
    {
        throw new NotImplementedException();
    }

    public bool IsBroken()
    {
        var result = !checkDoctorAppointmentOverlapLimit.IsValid(doctorId,appointmentTime.StartTime,appointmentTime.EndTime);
        return result;
    }
}
