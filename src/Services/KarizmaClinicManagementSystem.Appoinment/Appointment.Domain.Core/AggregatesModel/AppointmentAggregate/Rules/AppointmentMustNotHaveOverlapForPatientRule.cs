using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
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

public class AppointmentMustNotHaveOverlapForPatientRule : IBusinessRule
{
    private readonly Guid patientId;
    private readonly AppointmentTime appointmentTime;
    private readonly ICheckPatientAppointmentOverlap checkPatientAppointmentOverlap;

    public string Code => ErrorCode.OverlapWithPatientAppointment.Code;
    public string Message => ErrorCode.OverlapWithPatientAppointment.Message;
    public AppointmentMustNotHaveOverlapForPatientRule(Guid patientId, AppointmentTime appointmentTime, 
        IPatientRepository patientRepository)
    {
        CommonValidation.CheckNotNull(patientId, ErrorCode.IsNull(nameof(patientId)));
        CommonValidation.CheckNotNull(appointmentTime, ErrorCode.IsNull(nameof(appointmentTime)));
        CommonValidation.CheckNotNull(patientRepository, ErrorCode.IsNull(nameof(patientRepository)));
        this.patientId = patientId;
        this.appointmentTime = appointmentTime;
        this.checkPatientAppointmentOverlap = new CheckPatientAppointmentOverlap(patientRepository);
    }
    public void AdjustError(ErrorCode errorCode)
    {
        throw new NotImplementedException();
    }

    public bool IsBroken()
    {
        var result = !checkPatientAppointmentOverlap.IsValid(patientId, appointmentTime.StartTime, appointmentTime.EndTime);
        return result;
    }
}
