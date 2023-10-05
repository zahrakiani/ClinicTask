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

public class AppointmentMustNotHaveMoreThanMaxAppointmentPerDayRule : IBusinessRule
{
    int MaxPatientAppointmentPerDay = 2; // Move to appConfig Or get from db
    private Guid patientId;
    private AppointmentTime appointmentTime;
    private readonly ICheckPatientMaxAppointmentPerDay checkPatientMaxAppointment;

    public string Code => ErrorCode.MoreThanAllowedOfPatientAppointments(MaxPatientAppointmentPerDay).Code;
    public string Message => ErrorCode.MoreThanAllowedOfPatientAppointments(MaxPatientAppointmentPerDay).Message;

    public AppointmentMustNotHaveMoreThanMaxAppointmentPerDayRule(Guid patientId,
        AppointmentTime appointmentTime, 
        IPatientRepository patientRepository)
    {
        CommonValidation.CheckNotNull(patientId, ErrorCode.IsNull(nameof(patientId)));
        CommonValidation.CheckNotNull(appointmentTime, ErrorCode.IsNull(nameof(appointmentTime)));
        CommonValidation.CheckNotNull(patientRepository, ErrorCode.IsNull(nameof(patientRepository)));

        this.patientId = patientId;
        this.appointmentTime = appointmentTime;
        this.checkPatientMaxAppointment = new CheckPatientMaxAppointmentPerDay(patientRepository);
    }

    public bool IsBroken()
    {
        var result = !checkPatientMaxAppointment.IsValid(patientId,appointmentTime.StartTime);
        return result;
    }
}
